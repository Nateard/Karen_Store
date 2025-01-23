namespace Karen_Store.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

           // change passwords  to correct format
         
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RolesInRegisterUserDto> Roles { get; set; }
    }

}
