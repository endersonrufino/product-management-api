using ProductManagementApi.Models.Entities;

namespace ProductManagementApi.Infrastructure.Contexts
{
    public class SimpleDatabase
    {
        private List<Product> _produtos { get; set; }

        public SimpleDatabase()
        {

            InitialCharge();
        }

        public void InitialCharge()
        {
            if (_produtos == null || _produtos.Count == 0)
            {
                _produtos = new List<Product>
                {
                    new Product("Arroz", true, DateTime.Now, DateTime.Now, 1, "Tio João", "01234567890123"),
                    new Product("Feijão", false, DateTime.Now, DateTime.Now, 2, "Camil", "00234567890123")
                };
            }
        }

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
