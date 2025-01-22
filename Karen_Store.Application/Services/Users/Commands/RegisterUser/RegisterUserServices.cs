using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Users;

namespace Karen_Store.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserServices : IRegisterUserServices
    {
        private readonly IDatabaseContext _context;
        public RegisterUserServices(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                User user = new User()
                {
                    Email = request.Email,
                    Name = request.Name,
                    LastName = request.LastName,

                };
                List<UserInRole> userInRole = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var roles = _context.Role.Find(item.Id);
                    userInRole.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                        UserId = user.Id
                    });
                    user.UserInRole = userInRole;
                    _context.Users.Add(user);
                    _context.SaveChanges();

                }
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto
                    {
                        Id = user.Id,
                    },
                    Message = "ثبت نام کاربر انجام شد",
                    Success = true,
                };

            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
