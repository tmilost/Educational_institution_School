using SkolaProjektniCentar.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkolaProjektniCentar.Controllers
{
    [Filters.AutorizeAdmin]
    public class MailListeController : Controller
    {
        private SkolaContext _context;
        public MailListeController()
        {
            _context = new SkolaContext();
        }

        //Vraca sve mailove svih zaposlenih u bilo kojoj skoli
        public ActionResult Index()
        {
            var mailovi = _context.MailListe.ToList();
            return View(mailovi);
        }

        public ActionResult Stampaj()
        {
            var mailovi = _context.MailListe.ToList();
            return View(mailovi);
        }

        public ActionResult DodajMail()
        {
            var mlvm = new MailListeViewModel()
            {
                Osobe = _context.Osoba.ToList(),
                Tipovi = _context.TipMaila.ToList()
            };
            return View(mlvm);
        }

        //Metoda koja ucitava sve mailove iz baze
        public void UcitajTipoveMaila()
        {
            var mlvm = new MailListeViewModel();
            mlvm.Tipovi = _context.TipMaila.ToList();
        }

        //Metoda koja ucitava sve osobe iz baze
        public void UcitajOsobe()
        {
            var mlvm = new MailListeViewModel();
            mlvm.Osobe = _context.Osoba.ToList();
        }

        //Dodaje novi mail u bazu
        [HttpPost]
        public ActionResult DodajMail(MailListe mailListe)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MailListeViewModel
                {
                    IdMaila = mailListe.IdMaila,
                    Adresa = mailListe.Adresa,
                    Osobe = _context.Osoba.ToList(),
                    Tipovi = _context.TipMaila.ToList()
                };
                return View("DodajMail", viewModel);
            }

                _context.MailListe.Add(mailListe);
                _context.SaveChanges();
                return RedirectToAction("Index", "MailListe");
            
            
        }

        //Metoda koja vraca trazeni mail u bazi
        public MailListe PronadjiMail(long? id)
        {
            MailListe ml = new MailListe();
            ml = _context.MailListe.Where(x => x.IdMaila == id).FirstOrDefault();
            UcitajTipoveMaila();
            UcitajOsobe();
            return ml;
        }

        public ActionResult Izbrisi(long? id)
        {
            return View(PronadjiMail(id));
        }

        //Brise prosledjeni mail u bazi
        [HttpPost]
        public ActionResult Izbrisi(long? id, FormCollection fcNotUsed)
        {
            var mail = _context.MailListe.Where(x => x.IdMaila == id).FirstOrDefault();
            _context.MailListe.Remove(mail);
            _context.SaveChanges();
            return RedirectToAction("Index", "MailListe");
        }

        public ActionResult Izmeni(long? id)
        {
            var mail = _context.MailListe.SingleOrDefault(c => c.IdMaila == id);
            var viewModel = new MailListeViewModel
            {
                MailListe = mail,
                Tipovi = _context.TipMaila.ToList(),
                Osobe = _context.Osoba.ToList()
            };
            return View("Izmeni", viewModel);
        }

        //Brise prosledjeni mail u bazi
        [HttpPost]
        public ActionResult Izmeni(MailListeViewModel mail, long? id)
        {
            IzmeniMail(mail, id);
            return RedirectToAction("Index", "MailListe");
        }

        //Metoda koja nam pomaze da vrsimo brisanje u bazi
        public ActionResult IzmeniMail(MailListeViewModel mail, long? id)
        {
            var m = _context.MailListe.Find(id);
            if (m == null)
            {
                return new HttpNotFoundResult();
            }
            m.Adresa = mail.Adresa;
            m.IdTipaMaila = mail.IdTipaMaila;
            m.IdOsobe = mail.IdOsobe;
            _context.Entry(m).State = EntityState.Modified;
            _context.SaveChanges();
            return View(mail);
        }
    }
}