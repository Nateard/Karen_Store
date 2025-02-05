using FluentValidation;
using Karen_Store.Application.Services.Users.Commands.EditUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Karen_Store.Application.Services.Products.Commands.AddNewCategory.AddNewCategoryServices;

namespace Karen_Store.Application.Validation.CategoryValidation
{
    public class RequestAddCategoryValidation : AbstractValidator<AddNewCategoryDto>
    {
        public RequestAddCategoryValidation()
        {           
            RuleFor(o => o.Name)
                .NotEmpty()
                .WithMessage("لطفا نام را وارد کنید");
        }
    }
}
