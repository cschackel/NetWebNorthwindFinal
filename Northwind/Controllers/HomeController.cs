using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private INWRepo repo;
        public HomeController(INWRepo startRepo)
        {
            repo = startRepo;
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
        public ActionResult Index() => View(
            repo.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime >= DateTime.Now).OrderByDescending(d=>d.DiscountPercent).Take(3)
            );
        
    }
}