using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class Customer
    {
        
        public int CustomerID { get; set; }
        [Required]
        public String CompanyName {get;set;}
        public String Address {get;set;}
        public String City {get;set;}
        public String Region {get;set;}
        public String PostalCode {get;set;}
        public String Country {get;set;}
        public String Phone {get;set;}
        public String Fax {get;set;}

        [Required]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
    }
}