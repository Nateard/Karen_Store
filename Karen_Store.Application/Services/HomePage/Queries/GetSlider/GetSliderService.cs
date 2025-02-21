﻿using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
namespace Karen_Store.Application.Services.HomePage.Quereis.GetSlider
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.Id).Select(s => new SliderDto
            {
               Title = s.Name,
                Link = s.Link,
                Src = s.Src,
                Id = s.Id,  
            }).ToList();

            if (sliders.Any())
            {
                return new ResultDto<List<SliderDto>>
                {
                    Data = sliders,
                    IsSuccess = true,
                };

            }
            return new ResultDto<List<SliderDto>>
            {
                IsSuccess = false,
                Message = "Error"
            };
        }
    }
}
