//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelImplementation.ModelDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDE()
        {
            this.ORDERPRODUCT = new HashSet<ORDERPRODUCT>();
        }
    
        public long ID { get; set; }
        public string ORDERNUMBER { get; set; }
        public string CUSTOMERID { get; set; }
        public Nullable<decimal> GTOTAL { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERPRODUCT> ORDERPRODUCT { get; set; }
    }
}