using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkolaProjektniCentar.ViewModel
{
    public class KorisnikViewModel
    {
        public Korisnik Korisnik { get; set; }
        public long IdKorisnika { get; set; }
        [Required]
        [Display(Name = "Korisnicko ime")]
        [RegularExpression(@"[A-Za-z]{2,10}[0-9]{1}$", ErrorMessage = "Korisnicko ime treba da minimum 2, a maksimum 10 slova i 1 broj")]
        public string KorisnickoIme { get; set; }
        [Required]
        [Display(Name = "Lozinka")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Minimum 4, maksimum 8 karaktera, 1 veliko slovo i broj")]
        public string Lozinka { get; set; }
        [Required]
        [Display(Name = "Pravo Pristupa")]
        [RegularExpression(@"[1-3]{1}$", ErrorMessage = "Pravo Pristupa mora biti 1, 2 ili 3")]
        public int PravoPristupa { get; set; }
        public string LoginError { get; internal set; }
    }
}