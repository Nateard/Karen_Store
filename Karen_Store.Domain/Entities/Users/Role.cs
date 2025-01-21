namespace Karen_Store.Domain.Entities.Users
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
