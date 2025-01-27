using FluentValidation;
using Karen_Store.Application.Interfaces.Context;
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

            RuleFor(o => o.FullName)
                .NotEmpty()
                .WithMessage("لطفا نام را وارد کنید");


            RuleFor(o => o.Password)
                .NotEmpty().WithMessage("رمز عبور را وارد نمایید")
                .MinimumLength(5).WithMessage("رمز عبور باید بیشتر از 5 کاراکتر باشد")
                .Equal(o => o.RePassword).WithMessage("رمز عبور و تکرار آن برابر نیست");

        }

    }
}

