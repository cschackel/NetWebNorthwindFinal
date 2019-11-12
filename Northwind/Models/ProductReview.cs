using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }
        //private int CustomerId { get; set; }
        public Customer PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
        public decimal Rating { get; set; }
        public Product ForProduct { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
    }
}
