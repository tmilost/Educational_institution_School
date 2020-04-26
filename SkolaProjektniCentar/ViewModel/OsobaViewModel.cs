using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SkolaProjektniCentar.Models;

namespace SkolaProjektniCentar.ViewModel
{
    public class OsobaViewModel
    {
        public Osoba Osoba { get; set; }
        public long IdOsobe { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z]{2,20})$", ErrorMessage = "Unesite samo slova, u rasponu od 2 do 20 karaktera")]
        public string Ime { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z]{2,20})$", ErrorMessage = "Unesite samo slova, u rasponu od 2 do 20 karaktera")]
        public string Prezime { get; set; }
        [Display(Name = "Radno mesto")]
        [RegularExpression(@"[a-zA-Z ]{2,30}$", ErrorMessage = "Unesite samo slova, izmedju 2 i 30 karaktera")]
        public string RadnoMesto { get; set; }

        public Skola Skola { get; set; }
        [Display(Name = "Skola")]
        public long IdSkole { get; set; }
        public string Naziv { get; set; }
        public TipMaila TipMaila { get; set; }
        public string Tip { get; set; }

        public IEnumerable<Skola> Skole { get; set; }
    }
}
