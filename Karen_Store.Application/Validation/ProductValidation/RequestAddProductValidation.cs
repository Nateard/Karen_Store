using FluentValidation;
using Karen_Store.Application.Services.Products.Commands.AddNewProduct;
using Karen_Store.Application.Services.Users.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Validation.ProductValidation
{
    public class RequestAddProductValidation : AbstractValidator<RequestAddProductDto>
    {
        public RequestAddProductValidation()
        {
            RuleFor(o => o.Name)
                .NotEmpty()
                .WithMessage("لطفا نام محصول را وارد کنید");


            RuleFor(o => o.Price)
            .NotEmpty().WithMessage("لطفا قیمت محصول را وارد کنید")
            .GreaterThan(0).WithMessage("لطفا نام محصول را وارد کنید");

            RuleFor(o => o.Brand)
                .NotEmpty()
                .WithMessage("لطفا نام برند را وارد کنید");
        }
    }
}
