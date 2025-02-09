using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Common.Queries.GetCategory;
using Karen_Store.Application.Services.Common.Queries.GetMenuItem;
using Karen_Store.Application.Services.Products.Commands.AddNewCategory;
using Karen_Store.Application.Services.Products.FacadPatern;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Common.FacadePatterns
{
    public class CommonFacade : ICommonFacade
    {
        private readonly IDatabaseContext _context;
        public CommonFacade(IDatabaseContext context)
        {
                _context = context;
        }

        private IGetMenuItemService _getMenuItemService;
        public IGetMenuItemService GetMenuItemService =>
            _getMenuItemService ??= new GetMenuItemService (_context);
     

            private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService =>
            _getCategoryService ??= new GetCategoryService(_context);
    }
}
