namespace Karen_Store.Domain.Entities.Users
{
    public class UserInRole
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual Role Role { get; set; }    
        public long RoleId { get; set; }


    }
}
