using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {
        private INWRepo repo;

        private UserManager<AppUser> userManager;
        public CustomerController(INWRepo repo, UserManager<AppUser> usrMgr)
        {
            this.repo = repo;
            userManager = usrMgr;
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Register(CustomerWithPassword customerWithPassword)
        {
            if (ModelState.IsValid)
            {
                Customer customer = customerWithPassword.Customer;
                if (repo.Customers.Any(c => c.CompanyName == customer.CompanyName))
                {
                    ModelState.AddModelError("", "Company Name must be unique");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        AppUser user = new AppUser
                        {
                            // email and username are synced - this is by choice
                            Email = customer.Email,
                            UserName = customer.Email
                        };
                        // Add user to Identity DB
                        IdentityResult result = await userManager.CreateAsync(user, customerWithPassword.Password);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                        else
                        {
                            // Assign user to customers Role
                            result = await userManager.AddToRoleAsync(user, "Customer");

                            if (!result.Succeeded)
                            {
                                // Delete User from Identity DB
                                await userManager.DeleteAsync(user);
                                AddErrorsFromResult(result);
                            }
                            else
                            {
                                // Create customer (Northwind)
                                repo.addCustomer(customer);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            return View();
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Account() => View(repo.Customers.FirstOrDefault(c => c.Email == User.Identity.Name));

        [Authorize(Roles = "Customer"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult Account(Customer customer)
        {
            // Edit customer info
            repo.EditCustomer(customer);
            return RedirectToAction("Index", "Home");
        }
    }
}