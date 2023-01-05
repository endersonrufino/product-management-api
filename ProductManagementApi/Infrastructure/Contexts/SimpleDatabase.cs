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
                    new Product("Feijão", true, DateTime.Now, DateTime.Now, 2, "Tio João", "00234567890123"),
                    new Product("Coca Cola", true, DateTime.Now, DateTime.Now, 2, "Tio João", "00234567890123"),
                    new Product("Farinha Amarela", true, DateTime.Now, DateTime.Now, 2, "Tio João", "00234567890123"),
                    new Product("Trigo Dona Benta", true, DateTime.Now, DateTime.Now, 2, "Tio João", "00234567890123"),
                    new Product("Pão de Forma", true, DateTime.Now, DateTime.Now, 2, "Tio João", "00234567890123"),
                    new Product("Açucar Itamarati", true, DateTime.Now, DateTime.Now, 2, "Tio João", "00234567890123")
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

        public List<Product> FilterProducts(string name, DateTime expirationDate, DateTime manufacturingDate, int currentPage, int currentPageSize)
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

            var activeRegisters = products.Where(x => x.Active == true).ToList();

            return activeRegisters.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();
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
