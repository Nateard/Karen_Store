using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;
using Karen_Store.Application.Services.HomePage.Queries.GetHomePageImage;

namespace EndPoint.Site.Models.ViewModels.HomePage
{
    public class HomePageViewModel 
    {
        public List<SliderDto> Sliders { get; set; }

        public List<HomePageImageDto> PageImages { get; set;}
    }
}
