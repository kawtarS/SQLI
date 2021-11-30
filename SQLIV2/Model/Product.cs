using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLIV2.Model
{
    public class Product { 
        public string name { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
       public int quantity { get; set; }
       public int barcode { get; set; }
    
    }
}
