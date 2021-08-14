using ModelImplementation.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarritoComprasApp.Models
{
    public class OrderItems
    {
        public long ID { get; set; }
        public Nullable<long> ORDERID { get; set; }
        public Nullable<int> PRODUCTID { get; set; }
        public Nullable<int> QUANTITY { get; set; }

        public virtual ORDE ORDE { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }


    }
}
