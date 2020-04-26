using SkolaProjektniCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using SkolaProjektniCentar;
using SkolaProjektniCentar.ViewModel;
using System.Data.Entity;

namespace Projektni_centar_zadatak.Controllers
{
    [Filters.AutorizeAdmin]
    public class KorisnikController : Controller
    {
        private SkolaContext _context;
        public KorisnikController()
        {
            _context = new SkolaContext();
        }
        
        //Vraca sve korisnike sajta iz baze
        public ActionResult Index()
        {
            var korisnik = _context.Korisnik.ToList();
            return View(korisnik);
        }
        public ActionResult Stampaj()
        {
            var korisnik = _context.Korisnik.ToList();
            return View(korisnik);
        }

        public ActionResult DodajKorisnika()
        {
            var svm = new KorisnikViewModel();
            return View(svm);
        }

        //Dodaje novog korisnika u bazu
        [HttpPost]
        public ActionResult DodajKorisnika(KorisnikViewModel korisnik)
        {
            if (ModelState.IsValid)
            {
                var k = new Korisnik
                {
                    IdKorisnika = korisnik.IdKorisnika,
                    KorisnickoIme = korisnik.KorisnickoIme,
                    Lozinka = korisnik.Lozinka,
                    PravoPristupa = korisnik.PravoPristupa
                };
                _context.Korisnik.Add(k);
                _context.SaveChanges();
                return RedirectToAction("Index", "Korisnik");
            }
            return View(korisnik);
        }

        public ActionResult Izbrisi(long? id)
        {
            return View(PronadjiKorisnika(id));
        }

        //Brise prosledjenog korisnika iz baze
        [HttpPost]
        public ActionResult Izbrisi(long? id, FormCollection fcNotUsed)
        {
            SkolaContext _context;
            _context = new SkolaContext();
            var korisnik = _context.Korisnik.Where(x => x.IdKorisnika == id).FirstOrDefault();
            _context.Korisnik.Remove(korisnik);
            _context.SaveChanges();
            return RedirectToAction("Index", "Korisnik");
        }

        //Metoda koja trazi prosledjenog korisnika u baze
        public Korisnik PronadjiKorisnika(long? id)
        {
            SkolaContext _context;
            _context = new SkolaContext();
            Korisnik k = new Korisnik();
            k = _context.Korisnik.Where(x => x.IdKorisnika == id).FirstOrDefault();
            return k;
        }

        public ActionResult Izmeni(long? id)
        {
            return View(PronadjiKorisnika(id));
        }

        
        [HttpPost]
        public ActionResult Izmeni(KorisnikViewModel korisnik, long? id)
        {
            IzmeniKorisnika(korisnik, id);
            return RedirectToAction("Index", "Korisnik");
        }
        
        //Menja korisnika iz baze
        public ActionResult IzmeniKorisnika(KorisnikViewModel korisnik, long? id)
        {
            var k = _context.Korisnik.Find(id);
            if (k == null)
            {
                return new HttpNotFoundResult();
            }
            k.KorisnickoIme = korisnik.KorisnickoIme;
            k.Lozinka = korisnik.Lozinka;
            k.PravoPristupa = korisnik.PravoPristupa;
            _context.Entry(k).State = EntityState.Modified;
            _context.SaveChanges();
            return View(korisnik);
        }
    }
}