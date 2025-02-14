using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.HomePages.AddHomePageImages;
using Karen_Store.Domain.Entities.HomePage;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IHomePageFacade _homePageFacade;
        public HomePageImagesController(IHomePageFacade homePageFacad)
        {
            _homePageFacade = homePageFacad;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file, string link, ImageLocation imageLocation)
        {
            _homePageFacade.AddHomePageImagesService.Execute(new requestAddHomePageImagesDto
            {
                file = file,
                Link = link,
                ImageLocation = imageLocation,        
            } , saveTo: "HomePageImage");
            return View();
        }
        [HttpPost]
        public IActionResult Delete(long imageId)
        {
            return View();
        }
    }
}
