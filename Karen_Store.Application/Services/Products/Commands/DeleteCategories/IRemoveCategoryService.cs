using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Products.Commands.DeleteCategories
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(long Id);
    }
}
