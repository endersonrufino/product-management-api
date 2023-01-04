using Moq;
using ProductManagementApi.Models.Dtos;
using ProductManagementApi.Models.Entities;
using ProductManagementApi.Models.Interfaces;
using ProductManagementApi.Services;

namespace ProductManagementApi.Tests
{
    public class ProductTests
    {
        private ProductService productService;
        public ProductTests()
        {
            productService = new ProductService(new Mock<IProductRepository>().Object);
        }

        [Fact]
        public void Product_Is_Valid()
        {
            var exception = Assert.Throws<Exception>(() => productService.AddProduct(new ProductDto
            {
                Description = "",
                Active = true,
                ManufacturingDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                SupplierId = 1,
                SupplierDescription = "Tio João",
                SupplierCNPJ = "01234567890123"
            }));

            Assert.Equal("The description product is invalid", exception.Message);
        }
    }
}
