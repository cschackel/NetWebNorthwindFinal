using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        [Column("PostedByCustomerID")]
        public int? PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rating { get; set; }
        [Column("ForProductProductId")]
        public int? ForProduct { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        [ForeignKey("ForProduct")]
        [InverseProperty("Reviews")]
        public virtual Product Product { get; set; }
        [ForeignKey("PostedBy")]
        [InverseProperty("Reviews")]
        public virtual Customer Customer { get; set; }
    }
}
