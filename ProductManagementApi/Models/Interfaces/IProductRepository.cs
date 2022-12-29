using ProductManagementApi.Models;

namespace ProductManagementApi.Models.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product GetById(Guid id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
    }
}
