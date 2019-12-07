using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class ProductPageViewModel
    {
        public Product Product{get;set;}
        public bool CanComment { get; set; }
        

        public ProductPageViewModel(Product p, bool canComment)
        {
            Product = p;
            CanComment = canComment;
        }
    }
}
