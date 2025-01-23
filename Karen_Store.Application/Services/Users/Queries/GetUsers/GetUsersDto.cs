using Karen_Store.Domain.Entities.Users;

namespace Karen_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersDto 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
