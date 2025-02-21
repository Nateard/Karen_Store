using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePage;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageFacade _homePageFacade;
        public HomeController(ILogger<HomeController> logger , IHomePageFacade homePageFacade)
        {
            _homePageFacade = homePageFacade;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Response.Cookies.Append("message", "welcome to asp.net", new CookieOptions
            {
                HttpOnly = true,
                Secure = Request.IsHttps,
                Path = Request.PathBase.HasValue ? Request.PathBase.ToString() : "/",
                Expires = DateTime.Now.AddDays(100)
            });
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _homePageFacade.GetSliderService.Execute(),
                PageImages = _homePageFacade.GetHomePageImageService.Execute(),
            };

            return View(homePage);
        }
        public IActionResult ReadCookie()
        {
            string cookieValue;
            if (Request.Cookies.TryGetValue("Message", out cookieValue))
            {
                return Ok(cookieValue);
            } 
           return NotFound("???? ???? ???");
        }
        
        public IActionResult RemoveCookie()
        {
            Response.Cookies.Delete("Message");
            return Ok();
        }

        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
