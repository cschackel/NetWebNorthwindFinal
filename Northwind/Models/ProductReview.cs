using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class ProductReview
    {
        private int ReviewID { get; set; }
        private Customer PostedBy { get; set; }
        private DateTime PostedOn { get; set; }
        private decimal Rating { get; set; }
        private Product ForProduct { get; set; }
        private String Title { get; set; }
        private String Body { get; set; }
    }
}
