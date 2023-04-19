
using Domain.Contracts;

namespace Domain.Entities
{
    public class Product : AuditableEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double RegularPrice { get; set; } 
        public double SalePrice { get; set; } 
    }
}
