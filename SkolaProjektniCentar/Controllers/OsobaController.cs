using SkolaProjektniCentar.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkolaProjektniCentar.Models;

namespace SkolaProjektniCentar.Controllers
{
    [Filters.AutorizeAdmin]
    public class OsobaController : Controller
    {
        private SkolaContext _context;
        public OsobaController()
        {
            _context = new SkolaContext();
        }

        //Metoda koja ucitava sve skole iz baze
        public void UcitajSkole()
        {
            var ovm = new OsobaViewModel();
            ovm.Skole = _context.Skola.ToList();

        }

        //Vraca sve osobe, odnosno zaposlene u svim skolama iz baze
        [Filters.AutorizeAdmin]
        public ActionResult Index()
        {
            var osoba = _context.Osoba.Include(c => c.Skola).ToList();
            return View(osoba);
        }

        public ActionResult Stampaj()
        {
            var osoba = _context.Osoba.Include(c => c.Skola).ToList();
            return View(osoba);
        }

        public ActionResult DodajOsobu()
        {
            var ovm = new OsobaViewModel()
            {
                Skole = _context.Skola.ToList()
            };
            return View(ovm);
        }

        //Dodaje osobu(zaposlenog) u bazu
        [HttpPost]
        public ActionResult DodajOsobu(Osoba osoba)
        {
            if (!ModelState.IsValid)
            {
                var s = new OsobaViewModel
                {
                    IdOsobe = osoba.IdOsobe,
                    Ime = osoba.Ime,
                    Prezime = osoba.Prezime,
                    RadnoMesto = osoba.RadnoMesto,
                    Skole = _context.Skola.ToList()

                };
                
                return View("DodajOsobu", s);
            }
            _context.Osoba.Add(osoba);
            _context.SaveChanges();
            return RedirectToAction("Index", "Osoba");

        }

        public ActionResult Izbrisi(long? id)
        {
            return View(PronadjiOsobu(id));
        }

        //Brise prosledjenu osobu(zaposlenog) iz baze
        [HttpPost]
        public ActionResult Izbrisi(long? id, FormCollection fcNotUsed)
        {
            SkolaContext _context;
            _context = new SkolaContext();
            var osoba = _context.Osoba.Where(x => x.IdOsobe == id).FirstOrDefault();
            var Telefoni = _context.KontaktTelefon.ToList();
            var Mailovi = _context.MailListe.ToList();

            foreach (var item2 in Telefoni)
            {
                if (item2.IdOsobe == id)
                {
                    _context.KontaktTelefon.Remove(item2);
                }
            }
            foreach (var item3 in Mailovi)
            {
                if (item3.IdOsobe == id)
                {
                    _context.MailListe.Remove(item3);
                }
            }

            _context.Osoba.Remove(osoba);
            _context.SaveChanges();
            return RedirectToAction("Index", "Osoba");
        }

        //Metoda koja nam pomaze da pronadjemo prosledjenu osobu u bazi
        public Osoba PronadjiOsobu(long? id)
        {
            SkolaContext _context;
            _context = new SkolaContext();
            Osoba o = new Osoba();
            o = _context.Osoba.Where(x => x.IdOsobe == id).FirstOrDefault();
            return o;
        }

        //Vraca sve telefone prosledjene osobe iz baze
        [HttpGet]
        public ActionResult DetaljiTelefona(long id)
        {
            return View(PronadjiTelefoneOsobe(id));
        }

        //Vraca sve mailove prosledjene osobe iz baze
        [HttpGet]
        public ActionResult DetaljiMailova(long id)
        {
            return View(PronadjiMailoveOsoba(id));
        }

        //Metoda koja nam vraca sve telefone prosledjenog zaposlenog
        public IQueryable<KontaktTelefonViewModel> PronadjiTelefoneOsobe(long? id)
        {
            var podaci = _context.KontaktTelefon.Select(telefon => new KontaktTelefonViewModel
            {
                IdTelefona = telefon.IdTelefona,
                BrojTelefona = telefon.BrojTelefona,
                Lokal = telefon.Lokal,
                IdTipaTelefona = telefon.IdTipaTelefona,
                IdOsobe = telefon.IdOsobe

            });
            var telefoni = from n in podaci
                           where n.IdOsobe == id
                           select n;

            return telefoni;
        }

        //Metoda koja nam vraca sve mailove prosledjenog zaposlenog
        public IQueryable<MailListeViewModel> PronadjiMailoveOsoba(long? id)
        {
            var podaci = _context.MailListe.Select(mail => new MailListeViewModel
            {
                IdMaila = mail.IdMaila,
                Adresa = mail.Adresa,
                IdOsobe = mail.IdOsobe,
                IdTipaMaila = mail.IdTipaMaila
            });
            var mailovi = from n in podaci
                          where n.IdOsobe == id
                          select n;

            return mailovi;
        }

        public ActionResult Izmeni(long? id)
        {
            var osoba = _context.Osoba.SingleOrDefault(c => c.IdOsobe == id);
            var viewModel = new OsobaViewModel
            {
                Osoba = osoba,
                Skole = _context.Skola.ToList()
            };
            return View("Izmeni", viewModel);

        }

        //Vrsi izmenu osobe(zaposlenog) u bazi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Izmeni(Osoba osoba, long? id)
        {
            if (osoba == null)
                return HttpNotFound();
            if (!ModelState.IsValid)
            {
                var viewModel = new OsobaViewModel
                {
                    Osoba = osoba,
                    Skole = _context.Skola.ToList()
                };
                return View("Izmeni", viewModel);
            }
            _context.Entry(osoba).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index", "Osoba");
        }
    }
}
