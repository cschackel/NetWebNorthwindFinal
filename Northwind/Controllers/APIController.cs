﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class APIController : Controller
    {
        private INWRepo repository;
        public APIController(INWRepo repo) => repository = repo;

        [HttpGet, Route("api/product")]
        // returns all products
        public IEnumerable<Product> Get() => repository.Products.OrderBy(p => p.ProductName);

        [HttpGet, Route("api/product/{id}")]
        // returns specific product
        public Product Get(int id) => repository.Products.FirstOrDefault(p => p.ProductId == id);

        [HttpGet, Route("api/product/discontinued/{discontinued}")]
        // returns all products where discontinued = true/false
        public IEnumerable<Product> GetDiscontinued(bool discontinued) => repository.Products.Where(p => p.Discontinued == discontinued).OrderBy(p => p.ProductName);
        [HttpGet, Route("api/category/{CategoryId}/product")]
        // returns all products in a specific category
        public IEnumerable<Product> GetByCategory(int CategoryId) => repository.Products.Where(p => p.CategoryId == CategoryId).OrderBy(p => p.ProductName);

        [HttpGet, Route("api/category/{CategoryId}/product/discontinued/{discontinued}")]
        // returns all products in a specific category where discontinued = true/false
        public IEnumerable<Product> GetByCategoryDiscontinued(int CategoryId, bool discontinued) => repository.Products.Where(p => p.CategoryId == CategoryId && p.Discontinued == discontinued).OrderBy(p => p.ProductName);

        //Posts A Product Review
        [HttpPost, Route("api/addReview")]
        public ProductReview Post([FromBody] ProductReviewJSON productReview)
        {
            if(productReview.title!=null && !productReview.title.Equals("") && productReview.body!=null && !productReview.body.Equals(""))
            {
                return repository.addProductReview(productReview);
            }
            else
            {
                return null;
            }
        }

        //Gets Reviews for a Product
        [HttpPost, Route("api/product/{productID}/review")]
        public IEnumerable<ProductReview> GetReviewsByProductID(int productID)
        {
            IEnumerable<ProductReview> reviews = repository.ProductReviews.Where(pr => pr.Product.ProductId == productID).OrderByDescending(pr => pr.PostedOn);
            return reviews;
        }

    

    }
}
