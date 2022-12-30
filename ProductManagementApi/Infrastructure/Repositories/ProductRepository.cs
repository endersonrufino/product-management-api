using ProductManagementApi.Infrastructure.Contexts;
using ProductManagementApi.Models.Entities;
using ProductManagementApi.Models.Interfaces;

namespace ProductManagementApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private SimpleDatabase _database;

        public ProductRepository()
        {
            _database = new SimpleDatabase();
        }

        public void DeleteProduct(Product product)
        {
            _database.DeleteProduct(product.ProductId);
        }

        public Product GetById(Guid id)
        {
            return _database.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _database.GetProducts();
        }

        public void AddProduct(Product product)
        {
            _database.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _database.UpdateProduct(product);
        }
    }
}
