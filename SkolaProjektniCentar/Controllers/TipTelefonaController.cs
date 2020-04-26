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
    public class TipTelefonaController : Controller
    {
        private SkolaContext _context;
        public TipTelefonaController()
        {
            _context = new SkolaContext();
        }

        //Ispis svih tipova telefona iz baze
        public ActionResult Index()
        {
            var tipoviT = _context.TipTelefona.ToList();
            return View(tipoviT);
        }

        public ActionResult DodajTipTelefona()
        {
            var tvm = new TipTelefonaViewModel();
            return View(tvm);
        }

        //Dodavanje tipa telefona u bazu
        [HttpPost]
        public ActionResult DodajTipTelefona(TipTelefonaViewModel tipT)
        {
            if (ModelState.IsValid)
            {
                var tt = new TipTelefona
                {
                    IdTipaTelefona = tipT.IdTipaTelefona,
                    Tip = tipT.Tip
                };
                _context.TipTelefona.Add(tt);
                _context.SaveChanges();
                return RedirectToAction("Index", "TipTelefona");
            }
            return View(tipT);
        }

        public ActionResult Izbrisi(long? id)
        {
            return View(PronadjiTip(id));
        }

        //Brisanje tipa telefona iz baze
        [HttpPost]
        public ActionResult Izbrisi(long? id, FormCollection fcNotUsed)
        {
            var tip = _context.TipTelefona.Where(x => x.IdTipaTelefona == id).FirstOrDefault();
            _context.TipTelefona.Remove(tip);
            _context.SaveChanges();
            return RedirectToAction("Index", "TipTelefona");
        }

        //Metoda koja nam pomaze da pronadjemo tip telefona u bazi
        public TipTelefona PronadjiTip(long? id)
        {
            TipTelefona tm = new TipTelefona();
            tm = _context.TipTelefona.Where(x => x.IdTipaTelefona == id).FirstOrDefault();
            return tm;
        }
    }
}
