using Karen_Store.Domain.Entities.Common;

namespace Karen_Store.Domain.Entities.Users
{
    public class Role:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
