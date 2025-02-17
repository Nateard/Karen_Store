using Karen_Store.Domain.Entities.Common;

namespace Karen_Store.Domain.Entities.Products
{
    public class ProductImages : BaseEntity<long>
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string Src { get; set; }
    }
}