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
    
    public partial class Pokoje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pokoje()
        {
            this.Pobyty = new ObservableCollection<Pobyty>();
        }
    
        public int IdPokoju { get; set; }
        public Nullable<int> IdTypu { get; set; }
        public Nullable<int> IdCenyPokoju { get; set; }
    
        public virtual CenaPokoju CenaPokoju { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual  ObservableCollection<Pobyty> Pobyty { get; set; }
        public virtual TypPokoju TypPokoju { get; set; }
    }
}
