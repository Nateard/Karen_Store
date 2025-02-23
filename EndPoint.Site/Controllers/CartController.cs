using EndPoint.Site.Utilities;
using Karen_Store.Application.Services.Carts;
using Karen_Store.Common.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartServices;
        private readonly CookiesManager _cookiesManager;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
            _cookiesManager = new CookiesManager();
        }
        public IActionResult Index()
        {
            var browserId = _cookiesManager.GetBrowserId(HttpContext);
            var userId = ClaimUtility.GetUserId(User);           
            if (userId == null)
            {
                var cart = _cartServices.GetMyCartByBrowserId(browserId);
                return View(cart.Data);
            }

            var userCart = _cartServices.GetMyCartByUserId(userId);
            return View(userCart.Data);
        }
        public IActionResult Remove(long productId)
        {
            var userId = ClaimUtility.GetUserId(User);
            var browserId = _cookiesManager.GetBrowserId(HttpContext);
            ResultDto<CartDto>? cartResult = null;
            if (userId == null)
            {
                cartResult = _cartServices.GetMyCartByBrowserId(browserId);
            }
            else
            {
                cartResult = _cartServices.GetMyCartByUserId(userId);
            }

            if (cartResult.Data?.UserId == null || userId == cartResult.Data?.UserId)
            {
                _cartServices.RemoveFromCart(productId, browserId);
                return RedirectToAction("Index");
            }
            return View(cartResult.Data);

            //var userId = ClaimUtility.GetUserId(User);
            //var result = _cartServices.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), userId);
            ////var cart = _cartServices.GetCurrentUserCart(userId);
            //if (result.Data.UserId == null)
            //{
            //    _cartServices.RemoveFromCart(productId, _cookiesManager.GetBrowserId(HttpContext));
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    if(userId == result.Data.UserId)
            //        {
            //        _cartServices.RemoveFromCart(productId, _cookiesManager.GetBrowserId(HttpContext));
            //        return RedirectToAction("Index");
            //    }
            //}
            //return View(result.Data);
        }
        public IActionResult AddToCart(long productId)
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            if (userId == null)
            {
                var resultGuestAdd = _cartServices.AddToGuestCart(productId, _cookiesManager.GetBrowserId(HttpContext));
                return RedirectToAction("Index");
            }
            var resultAdd = _cartServices.AddToUserCart(productId, userId , _cookiesManager.GetBrowserId(HttpContext));
            return RedirectToAction("Index");

        }

        public IActionResult Add(long cartItemId)
        {
            _cartServices.Add(cartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(long cartItemId)
        {
            _cartServices.LowOff(cartItemId);
            return RedirectToAction("Index");
        }


   






    }

}
