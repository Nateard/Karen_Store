using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserServices
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

    public class RegisterUserServices : IRegisterUserServices
    {
        private readonly IDatabaseContext _context;
        public RegisterUserServices(IDatabaseContext context)
        {
           _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
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
    }
    public class RequestRegisterUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<RolesInRegistrationDto> Roles { get; set; }
    }


    public class RolesInRegistrationDto
    {
        public Guid Id { get; set; }
    }




    public class ResultRegisterUserDto
    {
        public Guid Id { get; set; }
    }

}
