using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.HomePage.Queries.GetHomePageImage
{
    public class GetHomePageImageService : IGetHomePageImageService
    {
        private readonly IDatabaseContext _context;
        public GetHomePageImageService(IDatabaseContext context)
        {
            _context = context; 
        }
        public ResultDto<List<HomePageImageDto>> Execute()
        {
            var result = _context.HomePageImage.OrderByDescending(p => p.Id)
                .Select(p => new HomePageImageDto()
                {
                    Id = p.Id,
                    Link = p.Link,
                    Src = p.Src,
                    Imagelocation = p.Location,
                }).ToList();
            if (result.Any())
            {
                return new ResultDto<List<HomePageImageDto>>
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Data = result
                };
            }
            return new ResultDto<List<HomePageImageDto>>
            {
                IsSuccess = false,
                Message = "No Images Were Found"
            };
        }
    }
}
