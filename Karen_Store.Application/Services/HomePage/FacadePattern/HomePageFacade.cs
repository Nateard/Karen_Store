using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Common.Commands;
using Karen_Store.Application.Services.HomePage.Commands.AddNewSlider;
using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;
using Karen_Store.Application.Services.HomePage.Queries.GetHomePageImage;
using Karen_Store.Application.Services.HomePages.AddHomePageImages;
using Microsoft.AspNetCore.Hosting;


namespace Karen_Store.Application.Services.HomePage.FacadePattern
{
    public class HomePageFacade : IHomePageFacade
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public HomePageFacade(IDatabaseContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;
  
        }
        private IAddNewSliderService _addNewSliderService;
        public IAddNewSliderService AddNewSliderService =>
            _addNewSliderService ??= new AddNewSliderService(_context, _environment);

        private IGetSliderService _getSliderService;
        public IGetSliderService GetSliderService => 
            _getSliderService ??= new GetSliderService(_context);

        private IAddHomePageImagesService _addHomePageImagesService;
        public IAddHomePageImagesService AddHomePageImagesService =>
            _addHomePageImagesService ??= new AddHomePageImagesService (_context , _environment);

        private IGetHomePageImageService _getHomePageImageService;
        public IGetHomePageImageService GetHomePageImageService =>
            _getHomePageImageService ??= new GetHomePageImageService(_context);

    }
}
