using ProductManagementApi.Models.Entities;

namespace ProductManagementApi.Models.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public List<Product> FilterProducts(string name, DateTime expirationDate, DateTime manufacturingDate, int currentPage, int currentPageSize);
        public Product GetById(Guid id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
    }
}
