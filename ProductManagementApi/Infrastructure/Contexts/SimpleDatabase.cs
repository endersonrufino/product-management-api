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
                    new Product("Arroz", true, DateTime.Now, DateTime.Now, 1, "Camil", "01234567890123"),
                    new Product("Feijão", false, DateTime.Now, DateTime.Now, 2, "Tio João", "00234567890123")
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

        public List<Product> FilterProducts(string name, DateTime expirationDate, DateTime manufacturingDate)
        {
            var products = _produtos.AsQueryable();


            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(x => x.Description.ToUpper().Contains(name.ToUpper()));
            }

            if (manufacturingDate != DateTime.MinValue)
            {
                products = products.Where(x => x.ManufacturingDate.Date >= manufacturingDate.Date && x.ManufacturingDate.Date <= manufacturingDate.Date);
            }

            if (expirationDate != DateTime.MinValue)
            {
                products = products.Where(x => x.ExpirationDate.Date >= expirationDate.Date && x.ExpirationDate.Date <= expirationDate.Date);

            }

            return products.Where(x => x.Active == true).ToList();
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

            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }

            if (existingProduct != null)
            {
                _produtos.Remove(existingProduct);

                existingProduct.Active = false;

                _produtos.Add(existingProduct);
            }
        }
    }
}
