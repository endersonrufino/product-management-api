using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagementApi.Models;
using ProductManagementApi.ViewModels;

namespace ProductManagementApi.Controllers
{
    [Route("/products")]
    public class ProductController : Controller
    {
        private List<Product> _products = new List<Product>{
            new Product("Arroz", true, DateTime.Now, DateTime.Now, 1, "Tio João", "01234567890123"),
            new Product("Feijão", false, DateTime.Now, DateTime.Now, 2, "Camil", "00234567890123")
        };
        
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {

                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult NewProduct([FromBody] ProductRequest product)
        {
            var newProduct = new Product(
                product.Description,
                product.Active,
                product.ManufacturingDate,
                product.ExpirationDate,
                product.SupplierId,
                product.SupplierDescription,
                product.SupplierCNPJ);

            _products.Add(newProduct);

             var response = new ResponseApi("Success", "Product successfully registered", _products);

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            var existingProduct = _products.FirstOrDefault(x => x.ProductId == product.ProductId);

            if(existingProduct == null)
            {
                return NotFound();
            }

            _products.Remove(existingProduct);

            _products.Add(product);

            var response = new ResponseApi("Success", "Product updated successfully", _products);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var existingProduct = _products.FirstOrDefault(x => x.ProductId == id);

            if (existingProduct == null)
            {
                return NotFound();
            }
            else
            {
                _products.Remove(existingProduct);
            }

            var response = new ResponseApi("Success", "Product deleted successfully", _products);

            return Ok(response);
        }    

        private class ResponseApi
        {
            public ResponseApi(string status, string message, List<Product> products)
            {
                Status = status;
                Message = message;
                Products = products;
            }

            public string Status { get; set; }
            public string Message { get; set; }
            public List<Product> Products { get; set; }
        }    
    }
}