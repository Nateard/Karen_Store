using Karen_Store.Domain.Entities.Common;
using Karen_Store.Domain.Entities.Orders;

namespace Karen_Store.Domain.Entities.Users
{
    public class User : BaseEntity<long>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        // public int NationalCode { get; set; }
        // public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        //public int Age { get; set; }
        // public decimal Balance { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
