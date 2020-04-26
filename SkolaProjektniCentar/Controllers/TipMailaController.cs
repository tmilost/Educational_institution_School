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
    public class TipMailaController : Controller
    {
        private SkolaContext _context;
        public TipMailaController()
        {
            _context = new SkolaContext();
        }
        
        //Vrca sve tipove mailova iz baze
        public ActionResult Index()
        {
            var tipoviM = _context.TipMaila.ToList();
            return View(tipoviM);
        }

        public ActionResult DodajTipMaila()
        {
            var tvm = new TipMailaViewModel();
            return View(tvm);
        }

        //Dodaje tip maila u bazu
        [HttpPost]
        public ActionResult DodajTipMaila(TipMailaViewModel tipM)
        {
            if (ModelState.IsValid)
            {
                var tm = new TipMaila
                {
                    IdTipaMaila = tipM.IdTipaMaila,
                    Tip = tipM.Tip
                };
                _context.TipMaila.Add(tm);
                _context.SaveChanges();
                return RedirectToAction("Index", "TipMaila");
            }
            return View(tipM);

        }

        public ActionResult Izbrisi(long? id)
        {
            return View(PronadjiTip(id));
        }

        //Brise tip maila iz baze
        [HttpPost]
        public ActionResult Izbrisi(long? id, FormCollection fcNotUsed)
        {
            var tip = _context.TipMaila.Where(x => x.IdTipaMaila == id).FirstOrDefault();
            _context.TipMaila.Remove(tip);
            _context.SaveChanges();
            return RedirectToAction("Index", "TipMaila");
        }

        //Metoda koja nam pomaze da pronadjemo tip maila u bazi
        public TipMaila PronadjiTip(long? id)
        {
            TipMaila tm = new TipMaila();
            tm = _context.TipMaila.Where(x => x.IdTipaMaila == id).FirstOrDefault();
            return tm;
        }
    }
}