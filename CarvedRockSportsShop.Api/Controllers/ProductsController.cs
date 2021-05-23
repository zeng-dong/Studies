using CarvedRock.Api.ApiModels;
using CarvedRock.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CarvedRock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _productLogic;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IProductLogic productLogic)
        {
            _productLogic = productLogic;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts(string category = "all")
        {
            _logger.LogInformation("Starting controller action GetProducts for {category}", category);

            return _productLogic.GetProductsForCategory(category);
        }
    }
}
