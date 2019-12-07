using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public interface INWRepo
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Discount> Discounts { get; }

        IQueryable<Customer> Customers { get; }

        IQueryable<ProductReview> ProductReviews { get; }

        IQueryable<Order> Orders { get; }

        IQueryable<OrderDetail> OrderDetails { get; }

        void EditCustomer(Customer customer);
        void addCustomer(Customer newCustomer);
        //void addReview(ProductReview productReview);
        bool customerPurchasedProduct(Customer c, Product p);

        ProductReview addProductReview(ProductReviewJSON productReviewJSON);
        

    }
}
