using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductManagementApi.Models.Dtos;
using ProductManagementApi.Models.Interfaces;
using System.Net;

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
            try
            {
                var products = _productService.GetProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(ex),
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            try
            {                
                var product = _productService.GetById(id);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(ex),
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet]
        [Route("/products/filterProducts")]
        public IActionResult FilterProductsByNameAndExpirationDateAndManufacturingDate(string name, DateTime expirationDate, DateTime manufacturingDate, int page, int pageSize)
        {
            try
            {
                var product = _productService.FilterProducts(name, expirationDate, manufacturingDate, page, pageSize);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(ex),
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }            
        }

        [HttpPost]
        public IActionResult NewProduct([FromBody] ProductDto product)
        {
            try
            {
                _productService.AddProduct(product);

                var response = new ResponseApi("Success", "Product successfully registered");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(ex),
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }           
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDto product)
        {
            try
            {
                _productService.UpdateProduct(product);

                var response = new ResponseApi("Success", "Product updated successfully");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(ex),
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }           
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromBody] ProductDto product)
        {
            try
            {
                _productService.DeleteProduct(product);

                var response = new ResponseApi("Success", "Product deleted successfully");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(ex),
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }            
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