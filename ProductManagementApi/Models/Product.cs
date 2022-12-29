using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductManagementApi.Models
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
        
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierId { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCNPJ { get; set; }
    }
}