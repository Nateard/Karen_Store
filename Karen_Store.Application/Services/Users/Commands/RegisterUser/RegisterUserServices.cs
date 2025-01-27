using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Validation.UserValidators;
using Karen_Store.Common;
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
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                return new ResultDto<ResultRegisterUserDto>
                {
                    IsSuccess = false,
                    Message = "این ایمیل قبلا ثبت شده است"
                };
            }
            var validator = new RequestRegisterUserValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
             
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0
                    },
                    IsSuccess = false,
                    Message = string.Join(", ", errorMessages)
                };
            }

            try
            {
                var passwordHash = Hasher.Hash(request.Password);
                User user = new User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    Password = passwordHash,
                    IsActive = true,
                    InsertDateTime = DateTime.UtcNow,
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
                        UserId = user.Id,
                    },
                    Message = "ثبت نام کاربر انجام شد",
                    IsSuccess = true,
                };

            }
            catch (Exception)
            {

                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام کاربر با مشکل مواجه شد"
                };

            }

        }
    }

}
