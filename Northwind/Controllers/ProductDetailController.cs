using System;
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

        public IActionResult Index(int id)
        {
            
            IQueryable<decimal> allRatings = _db.ProductReviews.Where(p => p.Product.ProductId == id).Select(r => r.Rating);
            decimal rating = -1;
            if (allRatings.Any())
            {
                rating = allRatings.Average();
                ViewBag.starRating = Math.Round(rating, MidpointRounding.AwayFromZero);
                ViewBag.rating = rating.ToString("N1");
                
            }
            else {
                ViewBag.starRating = -1;
                ViewBag.rating = "Item has not been rated yet" ;

            }


            return View(_db.Products.Include(p => p.Category)
            .Where(p => p.Discontinued == false).First(p => p.ProductId == id));
        }

        public IActionResult ProductReviews(int id) {
            decimal rating = _db.ProductReviews.Where(p => p.Product.ProductId == id).Select(r => r.Rating).Average();
            ViewBag.ID = id;

            //ViewBag.rating = rating;

            return View(_db.ProductReviews.Where(p => p.Product.ProductId == id));

        }
    }
}