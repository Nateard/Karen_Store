using Karen_Store.Domain.Entities.HomePage;

namespace Karen_Store.Application.Services.HomePage.Queries.GetHomePageImage
{
    public class HomePageImageDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation Imagelocation { get; set; }
    }
}
