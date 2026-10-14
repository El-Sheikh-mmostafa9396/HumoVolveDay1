using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HumoVolveDay1.Models;

namespace HumoVolveDay1.Controllers.V2
{
    [ApiController]
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController: ControllerBase
    {
        private static readonly List<Product> SampleProducts = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 25000m, CategoryName = "Electronics" },
            new Product { Id = 2, Name = "Mouse", Price = 200m, CategoryName = "Electronics" },
            new Product { Id = 3, Name = "Desk Chair", Price = 150m, CategoryName = "Furniture" },
            new Product { Id = 4, Name = "Pen Set", Price = 12.5m, CategoryName = "Stationery" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(SampleProducts);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = SampleProducts.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("category/{categoryName}")]
        public ActionResult<IEnumerable<Product>> GetByCategory(string categoryName)
        {
            var list = SampleProducts.Where(p => string.Equals(p.CategoryName, categoryName, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(list);
        }
    }
}
