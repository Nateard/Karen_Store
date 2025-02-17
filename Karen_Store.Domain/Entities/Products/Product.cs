using Karen_Store.Domain.Entities.Common;

namespace Karen_Store.Domain.Entities.Products
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int ViewCount { get; set; }
        public string? Description { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }
    }
}