using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Common.Queries.GetCategory;
using Karen_Store.Application.Services.Common.Queries.GetMenuItem;
using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;
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
            _getMenuItemService ??= new GetMenuItemService(_context);

        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService =>
            _getCategoryService ??= new GetCategoryService(_context);

    

    }
}
