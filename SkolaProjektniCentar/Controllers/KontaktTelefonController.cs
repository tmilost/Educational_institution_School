using SkolaProjektniCentar;
using SkolaProjektniCentar.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentProject.Controllers
{
    [Filters.AutorizeAdmin]
    public class KontaktTelefonController : Controller
    {
        private SkolaContext _context;
        public KontaktTelefonController()
        {
            _context = new SkolaContext();
        }

        //Vraca sve telefone iz baze
        public ActionResult Index()
        {
            var telefoni = _context.KontaktTelefon.ToList();
            return View(telefoni);
        }

        public ActionResult Stampaj()
        {
            var telefoni = _context.KontaktTelefon.ToList();
            return View(telefoni);
        }

        public ActionResult DodajTelefon()
        {
            var ktvm = new KontaktTelefonViewModel()
            {
                Osobe = _context.Osoba.ToList(),
                Tipovi = _context.TipTelefona.ToList()
            };
            return View(ktvm);
        }

        //Metoda koja ucitava sve tipove telefona iz baze
        public void UcitajTipoveTelefona()
        {
            var ktvm = new KontaktTelefonViewModel();
            ktvm.Tipovi = _context.TipTelefona.ToList();
        }

        //Metoda koja ucitava sve osobe iz baze
        public void UcitajOsobe()
        {
            var ktvm = new KontaktTelefonViewModel();
            ktvm.Osobe = _context.Osoba.ToList();
        }

        //Dodaje novi telefon odredjenog tipa i osobe u bazu
        [HttpPost]
        public ActionResult DodajTelefon(KontaktTelefon kontaktTelefon)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new KontaktTelefonViewModel
                {
                    IdTelefona=kontaktTelefon.IdTelefona,
                    BrojTelefona=kontaktTelefon.BrojTelefona,
                    Lokal=kontaktTelefon.Lokal,
                    Tipovi = _context.TipTelefona.ToList(),
                    Osobe= _context.Osoba.ToList()
                };
                return View("DodajTelefon", viewModel);
                
            }
            _context.KontaktTelefon.Add(kontaktTelefon);
            _context.SaveChanges();
            return RedirectToAction("Index", "KontaktTelefon");
        }

        //Metoda koja nam pomaze da pronadjemo telefon u bazi
        public KontaktTelefon PronadjiTelefon(long? id)
        {
            KontaktTelefon kt = new KontaktTelefon();
            kt = _context.KontaktTelefon.Where(x => x.IdTelefona == id).FirstOrDefault();
            UcitajTipoveTelefona();
            UcitajOsobe();
            return kt;
        }

        public ActionResult Izbrisi(long? id)
        {
            return View(PronadjiTelefon(id));
        }

        //Brise postojeci telefon iz baze
        [HttpPost]
        public ActionResult Izbrisi(long? id, FormCollection fcNotUsed)
        {
            var telefon = _context.KontaktTelefon.Where(x => x.IdTelefona == id).FirstOrDefault();
            _context.KontaktTelefon.Remove(telefon);
            _context.SaveChanges();
            return RedirectToAction("Index", "KontaktTelefon");
        }

        public ActionResult Izmeni(long? id)
        {
            var tel = _context.KontaktTelefon.SingleOrDefault(c => c.IdTelefona == id);
            var viewModel = new KontaktTelefonViewModel
            {
                KontaktTelefon = tel,
                Tipovi = _context.TipTelefona.ToList(),
                Osobe = _context.Osoba.ToList()
            };
            return View("Izmeni", viewModel);
        }

        //Menja podatke prosledjenog telefona u bazi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Izmeni(KontaktTelefon telefon, long? id)
        {
            if (telefon == null)
                return HttpNotFound();
            KontaktTelefon kontaktTelefon = _context.KontaktTelefon.FirstOrDefault(x => x.IdTelefona == id);
            if (kontaktTelefon != null)
            {
                kontaktTelefon.BrojTelefona = telefon.BrojTelefona;
                kontaktTelefon.Lokal = telefon.Lokal;
                kontaktTelefon.Tipovi = _context.TipTelefona.ToList();
                kontaktTelefon.Osobe = _context.Osoba.ToList();
                _context.SaveChanges();
                return RedirectToAction("Index", "KontaktTelefon");
            };            return RedirectToAction("Index", "Home");
        }
    }
}