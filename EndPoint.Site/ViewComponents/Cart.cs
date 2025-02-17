using EndPoint.Site.Utilities;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Carts;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class Cart:ViewComponent
    {
        public readonly ICartServices _cartServices;
        private readonly CookiesManager _cookiesManager;
        public Cart(ICartServices cartServices)
        {
            _cartServices = cartServices;
            _cookiesManager = new CookiesManager();
        }
        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartServices.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), userId).Data);
        }
    }
}
