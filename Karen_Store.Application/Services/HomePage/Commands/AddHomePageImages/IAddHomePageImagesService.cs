using Karen_Store.Common.Dto;
namespace Karen_Store.Application.Services.HomePages.AddHomePageImages
{
    public interface IAddHomePageImagesService
    {
        ResultDto Execute(requestAddHomePageImagesDto request ,string saveTo);
    }
}
