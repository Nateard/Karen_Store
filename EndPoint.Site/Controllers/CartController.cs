using EndPoint.Site.Utilities;
using Karen_Store.Application.Services.Carts;
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
            var userId = ClaimUtility.GetUserId(User);
            var result = _cartServices.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), userId);
            return View(result.Data);
        }
        public IActionResult Remove(long productId)
        {
            _cartServices.RemoveFromCart(productId, _cookiesManager.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
        public IActionResult AddToCart(long productId)
        {

            var resultAdd = _cartServices.AddToCart(productId, _cookiesManager.GetBrowserId(HttpContext));

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
