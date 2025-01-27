using FluentValidation;
using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Validation.UserValidators;
using Karen_Store.Common;
using Karen_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Karen_Store.Application.Services.Users.Commands.UserLogin
{
    public partial interface IUserLoginService
    {
        public class UserLoginService : IUserLoginService
        {
            private readonly IDatabaseContext _context;
            public UserLoginService(IDatabaseContext context)
            {
                _context = context;
            }
            public ResultDto<ResultUserloginDto> Execute(string email, string password)
            {

                var user = _context.Users.Include(p => p.UserInRole)
             .ThenInclude(p => p.Role)
             .Where(p => p.Email.Equals(email)
             && p.IsActive == true)
         .FirstOrDefault();
                if (user == null)
                {
                    return new ResultDto<ResultUserloginDto>()
                    {
                        Data = new ResultUserloginDto()
                        {

                        },
                        IsSuccess = false,
                        Message = "رمز عبور و یا ایمیل اشتباه وارد شده است",
                    };
                }
                var PasswordConfirm = Hasher.Verify(password, user.Password);
                if (PasswordConfirm == false)
                {
                    return new ResultDto<ResultUserloginDto>()
                    {
                        Data = new ResultUserloginDto()
                        {

                        },
                        IsSuccess = false,
                        Message = "رمز عبور و یا ایمیل اشتباه وارد شده است",
                    };
                }
                List<string> roles = new List<string>();
                foreach (var item in user.UserInRole)
                {
                    roles.Add(item.Role.Name);
                }
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {
                        Roles = roles,
                        UserId = user.Id,
                        Name = user.FullName,
                    },
                    IsSuccess = true,
                    Message = "ورود به سایت با موفقیت انجام شد",
                };
            }
        }
    }
}
