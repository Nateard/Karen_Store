using FluentValidation;
using Karen_Store.Application.Services.Users.Commands.EditUser;

namespace Karen_Store.Application.Validation.UserValidators
{
    public class RequestEditUserValidator : AbstractValidator<RequestEditUserDto>
    {
        public RequestEditUserValidator()
        {
            RuleFor(o => o.Email)
                .NotEmpty()
                .WithMessage("لطفا ایمیل را وارد کنید")
                .EmailAddress()
                .WithMessage("لطفا ایمیل را به صورت صحیح وارد کنید");

            RuleFor(o => o.FullName)
                .NotEmpty()
                .WithMessage("لطفا نام را وارد کنید");
        }
    }

}
