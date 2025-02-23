using EndPoint.Site.Utilities;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Carts;
using Karen_Store.Domain.Entities.Carts;
using Karen_Store.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class CartViewComponent:ViewComponent
    {
        public readonly ICartServices _cartServices;
        private readonly CookiesManager _cookiesManager;
        public CartViewComponent(ICartServices cartServices)
        {
            _cartServices = cartServices;
            _cookiesManager = new CookiesManager();
        }
        public IViewComponentResult Invoke()
        {

            var browserId = _cookiesManager.GetBrowserId(HttpContext);
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            var currentUserCart = _cartServices.GetMyCartByUserId(userId).Data;

            var cartExists = _cartServices.GetMyCartByBrowserId(browserId);
            if (cartExists.IsSuccess &&cartExists.Data.CartItems.Count>0 && cartExists.Data.UserId==null)
            {
                _cartServices.AssignCurrentCartToUser(browserId, userId);
                return View(viewName: "Cart", cartExists.Data);
            }
            //if (userId == null)
            //{
            //    var cart = _cartServices.GetMyCartByBrowserId(browserId);
            //    if (!cart.IsSuccess)
            //    {
            //        var createCart = _cartServices.CreateCartForGuest(browserId);
            //        var guestCart = _cartServices.GetMyCartByBrowserId(browserId);
            //        return View(viewName: "Cart", guestCart.Data);
            //    }
            //    return View(viewName: "Cart", cart.Data);
            //}
            if (currentUserCart.UserId == userId)
            {
                return View(viewName: "Cart", _cartServices.GetMyCartByUserId(userId).Data);
            }
            _cartServices.CreateCartForUser(userId);
            return View(viewName: "Cart", _cartServices.GetMyCartByUserId(userId).Data);
        }
        public IViewComponentResult RefreshCart()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartServices.GetMyCartByUserId(userId).Data);
        }
    }
}
