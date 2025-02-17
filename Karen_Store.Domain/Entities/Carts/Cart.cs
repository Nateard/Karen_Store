using Karen_Store.Domain.Entities.Common;
using Karen_Store.Domain.Entities.Users;

namespace Karen_Store.Domain.Entities.Carts
{
    public class Cart : BaseEntity
    {
        public User User { get; set; }
        public long? UserId { get; set; }
        public Guid BrowserId { get; set; }
        public bool IsFinished { get; set; }

        public ICollection<CartItem> CartItems { get; set; }


    }
}
