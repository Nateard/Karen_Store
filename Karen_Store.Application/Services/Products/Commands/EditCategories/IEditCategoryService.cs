using Karen_Store.Common.Dto;
using static Karen_Store.Application.Services.Products.Commands.EditCategories.EditCategoryService;

namespace Karen_Store.Application.Services.Products.Commands.EditCategories
{
    public interface IEditCategoryService
    {
        ResultDto Execute(EditCategoryDto input);
    }
}
