//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class CenaPokoju
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CenaPokoju()
        {
            this.Pokoje = new ObservableCollection<Pokoje>();
        }
    
        public int IdCenyPokoju { get; set; }
        public Nullable<decimal> CenaPokoju1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual  ObservableCollection<Pokoje> Pokoje { get; set; }
    }
}