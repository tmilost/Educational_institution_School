//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SkolaProjektniCentar
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skola
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skola()
        {
            this.Osobas = new HashSet<Osoba>();
        }
    
        public long IdSkole { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Opstina { get; set; }
        public string PostanskiBroj { get; set; }
        public string MaticniBroj { get; set; }
        public string PIB { get; set; }
        public string BrojRacuna { get; set; }
        public string WebStranica { get; set; }
        public string Pecat { get; set; }
        public string Beleska { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Osoba> Osobas { get; set; }
    }
}