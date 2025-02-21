using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Common.Commands;
using Karen_Store.Application.Services.Common.Queries.GetCategory;
using Karen_Store.Application.Services.Common.Queries.GetMenuItem;
using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;
using Microsoft.AspNetCore.Hosting;
namespace Karen_Store.Application.Services.Common.FacadePatterns
{
    public class CommonFacade : ICommonFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public CommonFacade(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IGetMenuItemService _getMenuItemService;
        public IGetMenuItemService GetMenuItemService =>
            _getMenuItemService ??= new GetMenuItemService(_context);

        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService =>
            _getCategoryService ??= new GetCategoryService(_context);
  
    }
}
