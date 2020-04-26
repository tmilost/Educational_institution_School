using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkolaProjektniCentar.ViewModel
{
    public class MailListeViewModel
    {
        public MailListe MailListe { get; set; }
        public long IdMaila { get; set; }
        [Required]
        [EmailAddress]
        public string Adresa { get; set; }
        public virtual TipMaila TipMaila { get; set; }
        public long IdTipaMaila { get; set; }
        public Osoba Osoba { get; set; }
        public long IdOsobe { get; set; }

        public IEnumerable<TipMaila> Tipovi { get; set; }
        public IEnumerable<Osoba> Osobe { get; set; }
    }
}