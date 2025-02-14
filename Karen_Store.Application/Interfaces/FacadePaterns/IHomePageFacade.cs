using Karen_Store.Application.Services.HomePage.Commands.AddNewSlider;
using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;
using Karen_Store.Application.Services.HomePages.AddHomePageImages;

namespace Karen_Store.Application.Interfaces.FacadePaterns
{
    public interface IHomePageFacade
    {
        IAddNewSliderService AddNewSliderService { get; }
        IGetSliderService GetSliderService { get; }
        IAddHomePageImagesService AddHomePageImagesService { get; }
    }
}
