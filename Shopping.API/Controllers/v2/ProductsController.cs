using System;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductContext.Products;
        }
    }
}

