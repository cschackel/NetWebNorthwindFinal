using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class NWRepo : INWRepo
    {
        private NWContext context;
        public NWRepo(NWContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;
        public IQueryable<Category> Categories => context.Categories;

        public IQueryable<Discount> Discounts => context.Discounts;

        public IQueryable<Customer> Customers => context.Customers;

        public IQueryable<ProductReview> ProductReviews => context.ProductReviews;

        public IQueryable<Order> Orders => context.Orders;

        public IQueryable<OrderDetail> OrderDetails => context.OrderDetails;

        public void addCustomer(Customer newCustomer)
        {
            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }

        public void addReview(ProductReview productReview)
        {
            context.ProductReviews.Add(productReview);
            context.SaveChanges();
        }

        

        //Determines If A Customer Has Purchased A Product
        public bool customerPurchasedProduct(Customer c, Product p)
        {
            bool customerHasPurchasedProduct = false; //Holding Var
            if (Orders.Any(o => o.CustomerID == c.CustomerID))  //If Any Customer Orders
            {
                IEnumerable<Order> allOrders = context.Orders.Where(o => o.CustomerID == c.CustomerID);  //All Orders By a Customer

                if (allOrders != null && allOrders.Any())  //If Customer Has Orders
                {
                    foreach (Order order in allOrders)  //Iterate Over All Orders
                    {
                        var allOrderDetails = context.OrderDetails.Where(od => od.Product.ProductId == p.ProductId && od.Order.OrderID == order.OrderID); //Look For OrderDetails With Applicibal OrderID and Product
                        if (allOrderDetails.Count() > 0)  //If Customer Hoas Order Detail with That Product
                        {
                            customerHasPurchasedProduct = true;  //Customer HAS Purchased Product
                            break;  //Terminate Loop
                        }
                    }
                }
            }
            return customerHasPurchasedProduct;  //Return Result
        }

        public void EditCustomer(Customer customer)
        {
            var customerToUpdate = context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            customerToUpdate.Address = customer.Address;
            customerToUpdate.City = customer.City;
            customerToUpdate.Region = customer.Region;
            customerToUpdate.PostalCode = customer.PostalCode;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.Fax = customer.Fax;
            context.SaveChanges();
        }
    }
}
