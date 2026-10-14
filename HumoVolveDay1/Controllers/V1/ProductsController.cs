using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HumoVolveDay1.Models;

namespace HumoVolveDay1.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : ControllerBase
    {



        [HttpGet]
        public IActionResult GetAll()
        {
            var product = new
            {
                Id = 1,
                Name = " labtop charger",
                Price = 2000
            };

            return Ok(product);
        }







    }
}
