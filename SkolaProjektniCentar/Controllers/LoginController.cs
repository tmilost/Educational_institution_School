using SkolaProjektniCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkolaProjektniCentar;
//IZMENITI IME AUTHORIZE
namespace Projektni_centar_zadatak.Controllers
{
    public class LoginController : Controller
    {

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //Vrsi logovanje na sajt
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authorize(SkolaProjektniCentar.Korisnik korisnik)
        {
            using (SkolaContext _context = new SkolaContext())
            {
                var details = _context.Korisnik.Where(x => x.KorisnickoIme == korisnik.KorisnickoIme && x.Lozinka == korisnik.Lozinka).FirstOrDefault();
                if (details == null || !ModelState.IsValid)
                {
                    korisnik.LoginError = "Pogresno korisnicko ime ili lozinka";
                    return View("Index", korisnik);
                }
                else
                {
                    Session["PravoPristupa"] = details.PravoPristupa;
                    Session["KorisnickoIme"] = details.KorisnickoIme;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        //Odjavljivanje sa sajta
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}