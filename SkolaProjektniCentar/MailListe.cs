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
    
    public partial class MailListe
    {
        public long IdMaila { get; set; }
        public string Adresa { get; set; }
        public long IdTipaMaila { get; set; }
        public long IdOsobe { get; set; }
    
        public virtual Osoba Osoba { get; set; }
        public virtual TipMaila TipMaila { get; set; }
    }
}
