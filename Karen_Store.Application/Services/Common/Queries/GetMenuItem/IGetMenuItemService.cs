using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }

    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDatabaseContext _context;
        public GetMenuItemService(IDatabaseContext context)
        {
             _context = context;    
        }

        public ResultDto<List<MenuItemDto>> Execute()
        {
            var category = _context.Categories
                .Include(p => p.SubCategories)
                .Where(p=> p.ParentCategoryId == null)
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Child = p.SubCategories.ToList().Select(s => new MenuItemDto
                    {
                        CatId = s.Id,
                        Name = s.Name,

                    }).ToList(),
                }).ToList();
            return new ResultDto<List<MenuItemDto>>()
            {
                IsSuccess = true,
                Message = "successful",
                Data = category     
            };
        }
    }

    public class MenuItemDto
    {
        public string Name { get; set; }
        public long CatId { get; set; }
        public List<MenuItemDto> Child { get; set; }
    }
}
