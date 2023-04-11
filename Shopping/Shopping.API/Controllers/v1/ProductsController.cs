using System;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Models;

namespace Shopping.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Obsolete]
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
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Name = $"Random {index}"
            });
        }
    }
}

