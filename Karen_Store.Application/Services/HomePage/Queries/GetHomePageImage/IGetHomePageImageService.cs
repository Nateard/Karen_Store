using Karen_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.HomePage.Queries.GetHomePageImage
{
    public interface IGetHomePageImageService
    {
        ResultDto<List<HomePageImageDto>> Execute();

    }
}
