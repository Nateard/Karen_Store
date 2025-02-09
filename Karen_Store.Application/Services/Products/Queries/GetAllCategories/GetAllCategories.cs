using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Karen_Store.Application.Services.Products.Queries.GetAllCategories
{
    public class GetAllCategories : IGetAllCategories
    {
        private readonly IDatabaseContext _context;
        public GetAllCategories(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ICollection<AllCategoriesDto>> Execute()
        {
            try
            {
                var Categories = _context.Categories
                    .Include(p => p.ParentCategory)
                    .Where(p => p.ParentCategoryId != null)
                    .Select(p => new AllCategoriesDto
                    {
                        Id = p.Id,
                       Name = $"{p.ParentCategory.Name} - {p.Name}",
                    }).ToList();
                if (Categories != null)
                {
                    return new ResultDto<ICollection<AllCategoriesDto>>()
                    {
                        Data = Categories,
                        IsSuccess = true,
                        Message = ""
                    };
                }
                return new ResultDto<ICollection<AllCategoriesDto>>()
                {
                    IsSuccess = false,
                    Message = "هیج دسته بندی یافت نشد"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
