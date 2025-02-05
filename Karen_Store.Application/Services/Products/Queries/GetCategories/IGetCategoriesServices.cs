using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoriesServices
    {
        ResultDto<List<GetCategoryDto>> Execute(long? parentId);
    }
}
