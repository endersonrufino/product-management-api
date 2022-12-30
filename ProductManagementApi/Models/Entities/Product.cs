using ProductManagementApi.Models.Dtos;

namespace ProductManagementApi.Models.Entities
{
    public class Product
    {
        public Product(string description, bool active, DateTime manufacturingDate, DateTime expirationDate, int supplierId, string supplierDescription, string sDupplierCNPJ)
        {
            ProductId = Guid.NewGuid();
            Description = description;
            Active = active;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
            SupplierId = supplierId;
            SupplierDescription = supplierDescription;
            SupplierCNPJ = sDupplierCNPJ;
        }

        public Product(Guid productId, string description, bool active, DateTime manufacturingDate, DateTime expirationDate, int supplierId, string supplierDescription, string supplierCNPJ)
        {
            ProductId = productId;
            Description = description;
            Active = active;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
            SupplierId = supplierId;
            SupplierDescription = supplierDescription;
            SupplierCNPJ = supplierCNPJ;
        }

        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierId { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCNPJ { get; set; }

        public ProductDto ConvertEntity()
        {
            var product = new ProductDto
            {
                ProductId = ProductId,
                Description = Description,
                Active = Active,
                ManufacturingDate = ManufacturingDate,
                ExpirationDate = ExpirationDate,
                SupplierId = SupplierId,
                SupplierDescription = SupplierDescription,
                SupplierCNPJ = SupplierCNPJ
            };

            return product;
        }

        public static ProductDto ConvertEntity(Product prod)
        {
            var product = new ProductDto
            {
                ProductId = prod.ProductId,
                Description = prod.Description,
                Active = prod.Active,
                ManufacturingDate = prod.ManufacturingDate,
                ExpirationDate = prod.ExpirationDate,
                SupplierId = prod.SupplierId,
                SupplierDescription = prod.SupplierDescription,
                SupplierCNPJ = prod.SupplierCNPJ
            };

            return product;
        }

        public static List<ProductDto> ConvertEntities(List<Product> prods)
        {
            var products = new List<ProductDto>();

            foreach (var prod in prods)
            {
                var product = ConvertEntity(prod);
                products.Add(product);
            }

            return products;
        }
    }
}
