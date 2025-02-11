using Karen_Store.Application.Interfaces.FacadePaterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class SliderController : Controller
    {
        private readonly IHomePageFacade _homePageFacade;
        public SliderController(IHomePageFacade homePageFacade)
        {
                _homePageFacade = homePageFacade;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file , string link)
        {
            _homePageFacade.AddNewSliderService.Execute(file, link);
            return View();
        }

    }
}
