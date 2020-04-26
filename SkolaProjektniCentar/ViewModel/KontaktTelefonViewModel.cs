using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkolaProjektniCentar.ViewModel
{
    public class KontaktTelefonViewModel
    {
        public KontaktTelefon KontaktTelefon { get; set; }
        public long IdTelefona { get; set; }
        [Required]
        [Display(Name = "Broj telefona")]
        [RegularExpression(@"^([0-9]{7,15})$", ErrorMessage = "Unesite cifre, u rasponu od 7 do 15.")]
        public string BrojTelefona { get; set; }
        [Required]
        [Display(Name = "Lokal")]
        [RegularExpression(@"^([0-9]{1,4})$", ErrorMessage = "Unesite cifre, u rasponu od 7 do 15.")]
        public int Lokal { get; set; }
        public virtual TipTelefona TipTelefona { get; set; }
        public long IdTipaTelefona { get; set; }
        public Osoba Osoba { get; set; }
        public long IdOsobe { get; set; }
        

        public IEnumerable<TipTelefona> Tipovi { get; set; }
        public IEnumerable<Osoba> Osobe { get; set; }
    }
}