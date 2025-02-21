using Karen_Store.Application.Services.HomePage.Quereis.GetSlider;
using Karen_Store.Application.Services.HomePage.Queries.GetHomePageImage;
using Karen_Store.Common.Dto;

namespace EndPoint.Site.Models.ViewModels.HomePage
{
    public class HomePageViewModel 
    {
        public ResultDto<List<SliderDto>> Sliders { get; set; }

        public ResultDto<List<HomePageImageDto>> PageImages { get; set;}
    }
}
