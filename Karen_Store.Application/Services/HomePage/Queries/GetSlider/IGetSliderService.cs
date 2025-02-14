using Karen_Store.Common.Dto;
namespace Karen_Store.Application.Services.HomePage.Quereis.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();

    }
}
