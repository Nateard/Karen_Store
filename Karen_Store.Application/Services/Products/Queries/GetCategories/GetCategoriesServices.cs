using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Karen_Store.Application.Services.Products.Queries.GetCategories
{
    public class GetCategoriesServices : IGetCategoriesServices

    {
        private readonly IDatabaseContext _context;
        public GetCategoriesServices(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetCategoryDto>> Execute(long? parentId)
        {
            var categories = _context.Categories
                .Include(p => p.ParentCategory)
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId == parentId)
                .Select(p => new GetCategoryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Parent = p.ParentCategory != null ? new ParentCategoryDto
                    {
                        Id = p.ParentCategory.Id,
                        Name = p.ParentCategory.Name
                    } : null,
                    HasChild = p.SubCategories.Any()
                })
                .ToList();

            return new ResultDto<List<GetCategoryDto>>()
            {
                Data = categories,
                IsSuccess = true
            };
        }
    }
}
