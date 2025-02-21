using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Validation.UserValidators;
using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Users.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;
        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditUserDto request)
        {

            if (_context.Users.Any(u => u.Email == request.Email && u.Id != request.Id))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "این ایمیل قبلا ثبت شده است"
                };
            }

            var validator = new RequestEditUserValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = string.Join(", ", errorMessages)
                };
            }
            var result = _context.Users.Find(request.Id);
            if (result == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            result.FullName = request.FullName;
            result.Email = request.Email;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت ویرایش شد"
            };
        }
    }
}
