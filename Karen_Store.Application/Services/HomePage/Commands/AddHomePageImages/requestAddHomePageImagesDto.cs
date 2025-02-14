using Karen_Store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Http;
namespace Karen_Store.Application.Services.HomePages.AddHomePageImages
{
    public class requestAddHomePageImagesDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
