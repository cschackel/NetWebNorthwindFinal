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

        public void addCustomer(Customer newCustomer)
        {
            context.Customers.Add(newCustomer);
            context.SaveChanges();
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
