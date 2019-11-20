using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    [Table("Order Details")]
    public partial class OrderDetail
    {
        [Column("OrderDetailID")]
        public int OrderDetailID { get; set; }
        [Column("OrderID")]
        public int OrderID { get; set; }
        [Column("ProductID")]
        public int ProductID { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        [Column(TypeName = "decimal(5, 3)")]
        public decimal Discount { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
    }
}
