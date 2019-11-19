using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly INWRepo _db;

        public ProductDetailController(INWRepo db)
        {
            _db = db;
        }

        public IActionResult Index(int id) => View(_db.Products.Include(p => p.Category)
            .Where(p => p.Discontinued == false).First(p => p.ProductId == id));
    }
}