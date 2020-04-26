using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using SkolaProjektniCentar.Models;

namespace SkolaProjektniCentar.ViewModel
{
    public class SkolaViewModel
    {
        public Skola Skola { get; set; }
        public long IdSkole { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z ]{2,30}$", ErrorMessage = "Unesite vrednost izmedju 2 i 30 karaktera")]
        public string Naziv { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z ]{2,35}[0-9]{1,5}$", ErrorMessage = "Unesite vrednost izmedju 2 i 40 karaktera. Adresa mora zadrzati broj.")]
        public string Adresa { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z ]{2,30}$", ErrorMessage = "Unesite vrednost izmedju 2 i 30 karaktera")]
        public string Opstina { get; set; }
        [Required]
        [Display(Name = "Postanski broj")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Unesite broj od 5 cifara")]
        public string PostanskiBroj { get; set; }
        [Required]
        [Display(Name = "Maticni broj")]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "Unesite broj od 8 cifara")]
        public string MaticniBroj { get; set; }
        [Required]
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "Unesite broj od 9 cifara")]
        public string PIB { get; set; }
        [Required]
        [Display(Name = "Broj racuna")]
        [RegularExpression(@"^(\d{17,22})$", ErrorMessage = "Unesite broj od 17 do 22 cifara")]
        public string BrojRacuna { get; set; }
        public string Pecat { get; set; }
        [Required]
        [Display(Name = "Web stranica")]
        [Url]
        public string WebStranica { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Granica iznosi 255 karaktera.")]
        public string Beleska { get; set; }
        [Display(Name = "Ucitaj sliku")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}