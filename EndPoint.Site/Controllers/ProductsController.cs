using Karen_Store.Application.Interfaces.FacadPaterns;
using Microsoft.AspNetCore.Mvc;
using Karen_Store.Application.Services.Products.Queries.GetProductsForSite;
using Karen_Store.Common.Dto;
namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        IProductFacade _productFacade;
        public ProductsController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }
        public IActionResult Index(OrderBy orderBy, string searchKey, long? catId = null, int page = 1, int pageSize = 20)
        {
            var result = _productFacade.GetProductsForSite.Execute(orderBy, searchKey, page, pageSize, catId);
            if (result == null || result.Data == null)
            {
                result = new ResultDto<ResultProductForSiteDto>
                {
                    Data = new ResultProductForSiteDto
                    {
                        Products = new List<ProductForSiteDto>(),
                        TotalRows = 0
                    },
                    IsSuccess = false, 
                    Message = "No products found"
                };
            }
            return View(result.Data);
        }

        public IActionResult Details(long id, int page = 1)
        {
            return View(_productFacade.GetProducDetailsForSite.Execute(id).Data);
        }



    }
}
