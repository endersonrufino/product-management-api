using Moq;
using ProductManagementApi.Infrastructure.Contexts;
using ProductManagementApi.Infrastructure.Repositories;
using ProductManagementApi.Models.Dtos;
using ProductManagementApi.Models.Interfaces;
using ProductManagementApi.Services;

namespace ProductManagementApi.Tests
{
    public class ProductTests
    {
        private SimpleDatabase _database;
        private ProductService productService;
        private ProductRepository _productRepository;
        public ProductTests()
        {
            productService = new ProductService(new Mock<IProductRepository>().Object);
            _database= new SimpleDatabase();
            _productRepository = new ProductRepository();

            _database.InitialCharge();
        }

        [Fact]
        public void Add_Product_Description_Is_Valid()
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
            
            Assert.Equal("The description product is invalid.", exception.Message);            
        }
        
        [Fact]
        public void Add_Product_Manufacturing_Date_Greater_Than_Expiration_Date()
        {
            var exception = Assert.Throws<Exception>(() => productService.AddProduct(new ProductDto
            {
                Description = "Feijão Carioca",
                Active = true,
                ManufacturingDate = DateTime.Now.AddDays(2),
                ExpirationDate = DateTime.Now,
                SupplierId = 1,
                SupplierDescription = "Tio João",
                SupplierCNPJ = "01234567890123"
            }));

            Assert.Equal("The manufacturing date cannot be greater than or equal to the expiration date.", exception.Message);
        }

        [Fact]
        public void Add_Product_Manufacturing_Date_Equals_Expiration_Date()
        {
            var exception = Assert.Throws<Exception>(() => productService.AddProduct(new ProductDto
            {
                Description = "Feijão Carioca",
                Active = true,
                ManufacturingDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                SupplierId = 1,
                SupplierDescription = "Tio João",
                SupplierCNPJ = "01234567890123"
            }));

            Assert.Equal("The manufacturing date cannot be greater than or equal to the expiration date.", exception.Message);
        }

        [Fact]
        public void Get_Product_By_Id_Product_Not_Found()
        {
            var id = new Guid("a6432ccd-bb3b-4c83-8403-507b301ee46a");

            var exception = Assert.Throws<Exception>(() => productService.GetById(id));

            Assert.Equal("Product not found.", exception.Message);
        }

        [Fact]
        public void Delete_Product()
        {
            var product = _productRepository.GetProducts().FirstOrDefault();
            
            _productRepository.DeleteProduct(product);

            var productDeleted = _productRepository.GetById(product.ProductId);

            Assert.True(productDeleted.Active == false);
        }        
    }
}
