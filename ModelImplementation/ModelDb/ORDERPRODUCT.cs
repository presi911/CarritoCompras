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
    
    public partial class ORDERPRODUCT
    {
        public long ID { get; set; }
        public Nullable<long> ORDERID { get; set; }
        public Nullable<int> PRODUCTID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
    
        public virtual ORDE ORDE { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}