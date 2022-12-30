using Microsoft.AspNetCore.Mvc;
using ProductManagementApi.Models.Dtos;
using ProductManagementApi.Models.Interfaces;

namespace ProductManagementApi.Controllers
{
    [Route("/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productService.GetById(id);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult NewProduct([FromBody] ProductDto product)
        {
            _productService.AddProduct(product);

            var response = new ResponseApi("Success", "Product successfully registered");

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDto product)
        {
            _productService.UpdateProduct(product);

            var response = new ResponseApi("Success", "Product updated successfully");

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(ProductDto product)
        {
            _productService.DeleteProduct(product);

            var response = new ResponseApi("Success", "Product deleted successfully");

            return Ok(response);
        }

        private class ResponseApi
        {
            public ResponseApi(string status, string message)
            {
                Status = status;
                Message = message;
            }

            public string Status { get; set; }
            public string Message { get; set; }
        }
    }
}