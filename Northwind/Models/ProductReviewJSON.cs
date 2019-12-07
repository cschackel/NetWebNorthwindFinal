using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class ProductReviewJSON
    {
        public String postedBy { get; set; }
        public decimal rating { get; set; }
        public int forProduct { get; set; }
        public String title { get; set; }
        public String body { get; set; }
    }
}
