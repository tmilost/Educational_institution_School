using SkolaProjektniCentar.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Rotativa;

namespace SkolaProjektniCentar.Controllers
{
    public class SkolaController : Controller
    {
        private SkolaContext _context;
        public SkolaController()
        {
            _context = new SkolaContext();
        }

        //Vraca sve skole iz baze
        [Filters.AutorizeAdmin]
        public ActionResult Index()
        {
            var skola = _context.Skola.ToList();
            return View(skola);
        }

        public ActionResult Stampaj()
        {
            var skola = _context.Skola.ToList();
            return View(skola);
        }

        //Vraca sve zaposlene osobe u trazenoj skoli preko LINQ upita
        [Filters.AutorizeAdmin]
        public IQueryable<OsobaViewModel> PronadjiSkoluIZaposlene(long? id)
        {
            var podaci = _context.Osoba.Select(osoba => new OsobaViewModel
            {
                IdOsobe = osoba.IdOsobe,
                Ime = osoba.Ime,
                Prezime = osoba.Prezime,
                RadnoMesto = osoba.RadnoMesto,
                IdSkole = osoba.IdSkole
            });
            var polozeni = from n in podaci
                           where n.IdSkole == id
                           select n;

            return polozeni;

        }

        //Ispisuje sve zaposlene u trazenoj skoli
        [Filters.AutorizeAdmin]
        public ActionResult Detalji(long id)
        {
            return View(PronadjiSkoluIZaposlene(id));

        }

        //Ispisuje podatke o trazenoj skoli
        [Filters.AutorizeAdmin]
        [HttpGet]
        public ActionResult DetaljiOSkoli(long id)
        {
            return View(PronadjiSkolu(id));

        }

        [Filters.AutorizeAdmin]
        public ActionResult DodajSkolu()
        {
            var svm = new SkolaViewModel();
            return View(svm);
        }

        //Dodaje prosledjenu skolu u bazu
        [Filters.AutorizeAdmin]
        [HttpPost]
        public ActionResult DodajSkolu(SkolaViewModel skola)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (skola.ImageUpload == null || skola.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Polje je obavezno");
            }
            else if (!validImageTypes.Contains(skola.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Molimo odaberite podatak sa ovim ekstenzijama: GIF, JPG ili PNG.");
            }

            if (ModelState.IsValid)
            {
                var s = new Skola
                {
                    IdSkole = skola.IdSkole,
                    Naziv = skola.Naziv,
                    Adresa = skola.Adresa,
                    Opstina = skola.Opstina,
                    PostanskiBroj = skola.PostanskiBroj,
                    MaticniBroj = skola.MaticniBroj,
                    PIB = skola.PIB,
                    BrojRacuna = skola.BrojRacuna,
                    WebStranica = skola.WebStranica,
                    Beleska = skola.Beleska
                };

                if (skola.ImageUpload != null && skola.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = "~/Slike";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), skola.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, skola.ImageUpload.FileName);
                    skola.ImageUpload.SaveAs(imagePath);
                    s.Pecat = imageUrl;
                }

                _context.Skola.Add(s);
                _context.SaveChanges();
                return RedirectToAction("Index", "Skola");
            }

            return View(skola);

        }

        [Filters.AutorizeAdmin]
        public ActionResult Izbrisi(long? id)
        {
            return View(PronadjiSkolu(id));
        }

        //Brise prosledjenu skolu iz baze
        [Filters.AutorizeAdmin]
        [HttpPost]
        public ActionResult Izbrisi(long? id, FormCollection fcNotUsed)
        {
            SkolaContext _context;
            _context = new SkolaContext();
            var osobe = _context.Osoba.ToList();
            var Telefoni = _context.KontaktTelefon.ToList();
            var Mailovi = _context.MailListe.ToList();
            foreach(var item in osobe)
            {
                if(item.IdSkole == id)
                {
                    _context.Osoba.Remove(item);
                    foreach (var item2 in Telefoni)
                    {
                        if(item2.IdOsobe == item.IdOsobe)
                        {
                            _context.KontaktTelefon.Remove(item2);
                        }
                    }
                    foreach (var item3 in Mailovi)
                    {
                        if (item3.IdOsobe == item.IdOsobe)
                        {
                            _context.MailListe.Remove(item3);
                        }
                    }
                }
            }
            var skola = _context.Skola.Where(x => x.IdSkole == id).FirstOrDefault();
            _context.Skola.Remove(skola);
            _context.SaveChanges();

            return RedirectToAction("Index", "Skola");
        }

        //Metoda koja nam pomaze da pronadjemo prosledjenu skolu u bazi
        [Filters.AutorizeAdmin]
        public Skola PronadjiSkolu(long? id)
        {
            SkolaContext _context;
            _context = new SkolaContext();

            Skola s = new Skola();
            s = _context.Skola.Where(x => x.IdSkole == id).FirstOrDefault();
            return s;
        }

        [Filters.AutorizeAdmin]
        public ActionResult Izmeni(long? id)
        {
            return View(PronadjiSkolu(id));
        }

        //Vrsi izmene prosledjene skole u bazi
        [Filters.AutorizeAdmin]
        [HttpPost]
        public ActionResult Izmeni(SkolaViewModel skola, long? id)
        {
            IzmeniSkolu(skola, id);
            return RedirectToAction("Index", "Skola");
        }

        //Metoda koja nam pomoze da izmenimo skolu, koju prosledjujemo ActionResult-u
        [Filters.AutorizeAdmin]
        public ActionResult IzmeniSkolu(SkolaViewModel skola, long? id)
        {
            var validImageTypes = new string[]
            {
                  "image/gif",
                  "image/gif",
                  "image/jpeg",
                  "image/pjpeg",
                  "image/png"
            };
            if (skola.ImageUpload == null || skola.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Polje je obavezno");
            }
            else if (!validImageTypes.Contains(skola.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Molimo odaberite podatak sa ovim ekstenzijama: GIF, JPG ili PNG.");
            }
            if (!ModelState.IsValid)
            {
                var s = _context.Skola.Find(id);
                if (s == null)
                {
                    return new HttpNotFoundResult();
                }
                s.Naziv = skola.Naziv;
                s.Adresa = skola.Adresa;
                s.Opstina = skola.Opstina;
                s.PostanskiBroj = skola.PostanskiBroj;
                s.MaticniBroj = skola.MaticniBroj;
                s.PIB = skola.PIB;
                s.BrojRacuna = skola.BrojRacuna;
                s.WebStranica = skola.WebStranica;
                s.Beleska = skola.Beleska;
                if (skola.ImageUpload != null && skola.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = "~/Slike";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), skola.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, skola.ImageUpload.FileName);
                    skola.ImageUpload.SaveAs(imagePath);
                    s.Pecat = imageUrl;
                }
                _context.Entry(s).State = EntityState.Modified;
                _context.SaveChanges();
                return View(skola);
            }
            return RedirectToAction("Izmeni", "Skola");
        }
    }
}