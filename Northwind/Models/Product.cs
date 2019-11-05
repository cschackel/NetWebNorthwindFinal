using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class Product
    {
        public int ProductId{get;set;}
        public String ProductName { get; set; }
        public String QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
