using ProductManagementApi.Models.Entities;

namespace ProductManagementApi.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Is_Valid()
        {
            var product = new Product("Arroz", true, DateTime.Now, DateTime.Now, 1, "Tio João", "01234567890123");

            

        }
    }
}
