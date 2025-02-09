using Karen_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Products.Queries.GetProductsForSite
{
    public interface IGetProductsForSite
    {
        ResultDto<ResultProductForSiteDto> Execute(OrderBy orderBy,string searchKey ,int page ,int pageSize, long? CatId);
    }
}
