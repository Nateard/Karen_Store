using Karen_Store.Common.Dto;
using static Karen_Store.Application.Services.Products.Commands.EditCategories.EditCategory;

namespace Karen_Store.Application.Services.Products.Commands.EditCategories
{
    public interface IEditCategory
    {
        ResultDto Execute(EditCategoryDto input);
    }
}
