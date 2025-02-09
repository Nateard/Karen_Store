using Karen_Store.Domain.Entities.Common;

namespace Karen_Store.Domain.Entities.Product
{
    public class ProductFeatures : BaseEntity<long>
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}