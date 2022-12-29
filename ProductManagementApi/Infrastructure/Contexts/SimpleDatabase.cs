using ProductManagementApi.Models;

namespace ProductManagementApi.Infrastructure.Contexts
{
    public class SimpleDatabase
    {
        private List<Product> _produtos { get; set; }

        public List<Product> GetProducts()
        {
            return _produtos;
        }
        
        public Product GetProductById(Guid id)
        {
            return _produtos.FirstOrDefault(x => x.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            _produtos.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.ProductId);

            if (existingProduct != null)
            {
                _produtos.Remove(existingProduct);
                _produtos.Add(product);
            }
        }

        public void DeleteProduct(Guid id)
        {
            var existingProduct = GetProductById(id);

            if (existingProduct != null)
            {
                _produtos.Remove(existingProduct);
            }
        }
    }
}
