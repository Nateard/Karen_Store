using Karen_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategories
    {
        ResultDto<ICollection<AllCategoriesDto>> Execute();

    }
}
