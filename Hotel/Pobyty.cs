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
    
    public partial class Pobyty
    {
        public int IdPobytu { get; set; }
        public System.DateTime DataPrzyjazdu { get; set; }
        public System.DateTime DataWyjazdu { get; set; }
        public Nullable<int> IdPokoju { get; set; }
        public Nullable<int> IdPracownika { get; set; }
        public Nullable<int> IdUslugi { get; set; }
        public Nullable<int> IdKlienta { get; set; }
    
        public virtual Klienci Klienci { get; set; }
        public virtual Pokoje Pokoje { get; set; }
        public virtual Pracownicy Pracownicy { get; set; }
        public virtual Uslugi Uslugi { get; set; }
    }
}