using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        private INWRepo repo;
        public ProductController(INWRepo startRepo)
        {
            repo = startRepo;
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
    }
}