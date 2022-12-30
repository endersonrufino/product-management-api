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
            var entity = product.ConvertEntity();

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

            var result = product.ConvertEntity();

            return result;
        }

        public List<ProductDto> GetProducts()
        {
            return Product.ConvertEntities(_repository.GetProducts());
        }

        public void UpdateProduct(ProductDto product)
        {
            var entity = product.ConvertEntity();

            _repository.UpdateProduct(entity);
        }
    }
}
