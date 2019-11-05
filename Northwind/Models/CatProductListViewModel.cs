using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class CatProductListViewModel
    {
        public String catName { get; set; }
        public int catID { get; set; }

        public IEnumerable<Product> productList { get; set; }
    }
}
