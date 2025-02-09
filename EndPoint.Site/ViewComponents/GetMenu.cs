using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;
namespace EndPoint.Site.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly ICommonFacade _commonFacade;
        public GetMenu(ICommonFacade commonFacade)
        {
           _commonFacade = commonFacade;
        }
        public IViewComponentResult Invoke()
        {
            var menueItem = _commonFacade.GetMenuItemService.Execute();
            return View(viewName:"GetMenu", menueItem.Data);
        }
    }
}
