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
    
    public partial class TipTelefona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipTelefona()
        {
            this.KontaktTelefons = new HashSet<KontaktTelefon>();
        }
    
        public long IdTipaTelefona { get; set; }
        public string Tip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KontaktTelefon> KontaktTelefons { get; set; }
    }
}