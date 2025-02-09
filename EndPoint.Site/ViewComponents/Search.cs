using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Common.Queries.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly ICommonFacade _facade;
        public Search(ICommonFacade facade)
        {
               _facade = facade;    
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName:"Search" , _facade.GetCategoryService.Execute().Data);
        }
    }
}
