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
            var sliders = _homePageFacade.GetSliderService.Execute();         
            return View(sliders.Data);
        }


        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file , string link, string name)
        {
            _homePageFacade.AddNewSliderService.Execute(file, link, name);
            return View();
        }

    }
}
