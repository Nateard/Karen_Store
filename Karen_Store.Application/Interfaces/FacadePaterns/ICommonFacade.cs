using Karen_Store.Application.Services.Common.Commands;
using Karen_Store.Application.Services.Common.Queries.GetCategory;
using Karen_Store.Application.Services.Common.Queries.GetMenuItem;
using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;

namespace Karen_Store.Application.Interfaces.FacadePaterns
{
    public interface ICommonFacade
    {
        IGetMenuItemService GetMenuItemService { get; }
        IGetCategoryService GetCategoryService { get; }
      
    }
}
