using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        private INWRepo repo;
        private UserManager<AppUser> userManager;
        public ProductController(INWRepo startRepo, UserManager<AppUser> userManager)
        {
            repo = startRepo;
            this.userManager = userManager;
        }
        public IActionResult Category()
        {
            return View(repo.Categories);
        }

        public IActionResult Index(int id)
        {
            Category c = repo.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            CatProductListViewModel model = new CatProductListViewModel();
            model.catID = c.CategoryId;
            model.catName = c.CategoryName;
            IEnumerable<Product> productList = repo.Products.Where(p => p.CategoryId==model.catID && p.Discontinued == false).OrderBy(p=>p.ProductName);
            model.productList = productList;
            return View(model);
        }

        public IActionResult Discounts()
        {
            return View(repo.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime >= DateTime.Now).OrderByDescending(d => d.DiscountPercent));
        }

        public IActionResult Product(int id)
        {
            Product product = repo.Products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        public IActionResult Test(int id)
        {
            Product product = repo.Products.FirstOrDefault(p => p.ProductId == id);
            // get product reviews ordered by date posted with most recent first
            IEnumerable<ProductReview> reviews = repo.ProductReviews.Where(pr => pr.Product.ProductId == id).OrderByDescending(pr => pr.PostedOn);
            ViewBag.reviews = reviews;
            Customer customer;
            bool canComment = false;
            if(User!= null && User.Identity!=null&&User.Identity.Name!=null)
            {
                customer = repo.Customers.FirstOrDefault(c => c.Email == User.Identity.Name);
                if(customer!=null && product!=null)
                {
                    canComment = repo.customerPurchasedProduct(customer, product);
                }
                //canComment =  repo.customerPurchasedProduct(customer, product);
            }
            ProductPageViewModel ppvm = new ProductPageViewModel(product,canComment);
            
            return View(ppvm);
        }


    }
}