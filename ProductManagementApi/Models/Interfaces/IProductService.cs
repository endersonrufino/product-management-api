using ProductManagementApi.Models.Dtos;

namespace ProductManagementApi.Models.Interfaces
{
    public interface IProductService
    {
        public List<ProductDto> GetProducts();
        public ProductDto GetById(Guid id);
        public void AddProduct(ProductDto product);
        public void UpdateProduct(ProductDto product);
        public void DeleteProduct(ProductDto product);
        public List<ProductDto> FilterProducts(string name, DateTime expirationDate, DateTime manufacturingDate, int currentPage, int currentPageSize);
    }
}
