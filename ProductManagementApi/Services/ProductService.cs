using ProductManagementApi.Models.Dtos;
using ProductManagementApi.Models.Entities;
using ProductManagementApi.Models.Interfaces;

namespace ProductManagementApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(ProductDto product)
        {
            IsProductValid(product);

            var entity = product.ConvertNewProduct();

            _repository.AddProduct(entity);
        }

        public void DeleteProduct(ProductDto product)
        {
            var entity = product.ConvertEntity();

            _repository.DeleteProduct(entity);
        }

        public ProductDto GetById(Guid id)
        {            
            var product = _repository.GetById(id);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            var result = product.ConvertEntity();

            return result;
        }

        public List<ProductDto> GetProducts()
        {
            return Product.ConvertEntities(_repository.GetProducts());
        }

        public List<ProductDto> FilterProducts(string name, DateTime expirationDate, DateTime manufacturingDate)
        {
            return Product.ConvertEntities(_repository.FilterProducts(name, expirationDate, manufacturingDate));
        }

        public void UpdateProduct(ProductDto product)
        {
            IsProductValid(product);

            var entity = product.ConvertEntity();

            _repository.UpdateProduct(entity);
        }

        private void IsProductValid(ProductDto product)
        {
            if (string.IsNullOrEmpty(product.Description))
            {
                throw new Exception("The description product is invalid.");
            }

            if (product.ManufacturingDate.ToString().Equals(product.ExpirationDate.ToString()) || product.ManufacturingDate > product.ExpirationDate)
            {
                throw new Exception("The manufacturing date cannot be greater than or equal to the expiration date.");
            }
        }
    }
}
