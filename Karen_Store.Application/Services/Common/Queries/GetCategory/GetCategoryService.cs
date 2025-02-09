using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
namespace Karen_Store.Application.Services.Common.Queries.GetCategory
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDatabaseContext _context;
        public GetCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoryDto>> Execute()
        {
            var result = _context.Categories.Where(p => p.ParentCategoryId == null)
                .Select(p => new CategoryDto
                {
                    CategoryName = p.Name,
                    CatId = p.Id,
                }).ToList();
            if (result.Any())
            {
                return new ResultDto<List<CategoryDto>>
                {
                    IsSuccess = true,
                    Data = result
                };
            }
            return new ResultDto<List<CategoryDto>> { IsSuccess = false, Message = "دسته بندی یافت نشد" };
        }
    }
}
