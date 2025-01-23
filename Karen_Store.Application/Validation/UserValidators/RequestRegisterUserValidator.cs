using FluentValidation;
using Karen_Store.Application.Services.Users.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Validation.UserValidators
{
    public class RequestRegisterUserValidator : AbstractValidator<RequestRegisterUserDto>
    {
        public RequestRegisterUserValidator()
        {
            RuleFor(o => o.Email)
                .NotEmpty()
                .WithMessage("لطفا ایمیل را وارد کنید")
                .EmailAddress()
                .WithMessage("لطفا ایمیل را به صورت صحیح وارد کنید");

            RuleFor(o => o.Name)
                .NotEmpty()
                .WithMessage("لطفا نام را وارد کنید");

            RuleFor(o => o.LastName)
                .NotEmpty()
                .WithMessage("لطفا نام خانوادگی را وارد کنید");

            RuleFor(o => o.Password)
                .NotEmpty().WithMessage("رمز عبور را وارد نمایید")
                .Equal(o => o.RePassword).WithMessage("رمز عبور و تکرار آن برابر نیست");

        }
    }
}

