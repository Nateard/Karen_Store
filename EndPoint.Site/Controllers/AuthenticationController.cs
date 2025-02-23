using EndPoint.Site.Models.ViewModels.AuthenticationViewModel;
using EndPoint.Site.Utilities;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Carts;
using Karen_Store.Application.Services.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserFacade _userFacade;
        //private readonly IUserLoginService _userLoginServices;
        private readonly CookiesManager _cookieManager;
        private readonly ICartServices _cartServices;
        public AuthenticationController(IUserFacade userFacade, ICartServices cartServices)
        {
            _userFacade = userFacade;
            _cartServices = cartServices;
            _cookieManager = new CookiesManager();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignupViewModel request)
        {
            var singUpResult = _userFacade.RegisterUserService.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RolesInRegisterUserDto>
                {
                    new RolesInRegisterUserDto{ Id = 3 }
                }

            });
            if (singUpResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,singUpResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, request.FullName),
                new Claim(ClaimTypes.Role, "Customer"),
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);
                var browserId = _cookieManager.GetBrowserId(HttpContext);
                var userId = ClaimUtility.GetUserId(HttpContext.User);
                var cart = _cartServices.GetMyCartByBrowserId(browserId);
                if (cart.IsSuccess)
                {
                    _cartServices.AssignCurrentCartToUser(browserId, userId);
                }
            }
            return Json(singUpResult);
        }

        [HttpPost]
        public IActionResult Signin(string Email, string Password, string url = "/")
        {
            var signupResult = _userFacade.UserLoginService.Execute(Email, Password);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, signupResult.Data.Name),

            };
                foreach (var item in signupResult.Data.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);
                
            }
            
            //_cartServices.GetCurrentUserCart(signupResult.Data.UserId);
            return Json(signupResult);
        }

        public IActionResult Signin(string ReturnUrl = "/")
        {
          
            ViewBag.url = ReturnUrl;
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}


