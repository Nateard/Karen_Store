using Karen_Store.Common.Dto;
using static Karen_Store.Application.Services.Products.Commands.AddNewCategory.AddNewCategoryServices;

namespace Karen_Store.Application.Services.Products.Commands.AddNewCategory
{
    public interface IAddNewCategoryServices
    {
        ResultDto Execute(AddNewCategoryDto request);
    }
}
