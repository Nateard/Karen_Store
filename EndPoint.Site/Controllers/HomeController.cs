using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePage;
using Karen_Store.Application.Interfaces.FacadePaterns;
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
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _homePageFacade.GetSliderService.Execute().Data,
            };

            return View(homePage);
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
