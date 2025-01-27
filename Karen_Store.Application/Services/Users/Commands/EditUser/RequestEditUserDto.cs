namespace Karen_Store.Application.Services.Users.Commands.EditUser
{
    public class RequestEditUserDto
    {
        public long Id { get; set; }    
        public string FullName { get; set; }
        public string Email { get; set; } 
    }
}
