using ProductManagementApi.Models.Entities;

namespace ProductManagementApi.Models.Dtos
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierId { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCNPJ { get; set; }

        public Product ConvertEntity()
        {
            var product = new Product(
                    ProductId,
                    Description,
                    Active,
                    ManufacturingDate,
                    ExpirationDate,
                    SupplierId,
                    SupplierDescription,
                    SupplierCNPJ);

            return product;
        }

        public Product ConvertNewProduct()
        {
            var product = new Product(                    
                    Description,
                    Active,
                    ManufacturingDate,
                    ExpirationDate,
                    SupplierId,
                    SupplierDescription,
                    SupplierCNPJ);

            return product;
        }

        public static Product ConvertEntity(ProductDto dto)
        {
            var product = new Product(
                    dto.ProductId,
                    dto.Description,
                    dto.Active,
                    dto.ManufacturingDate,
                    dto.ExpirationDate,
                    dto.SupplierId,
                    dto.SupplierDescription,
                    dto.SupplierCNPJ);

            return product;
        }

        public static List<Product> ConvertEntities(List<ProductDto> dtos)
        {
            var products = new List<Product>();

            foreach (var dto in dtos)
            {
                var product = ConvertEntity(dto);
                products.Add(product);
            }

            return products;
        }
    }
}
