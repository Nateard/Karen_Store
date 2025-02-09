using Karen_Store.Application.Interfaces.FacadPaterns;
using Karen_Store.Application.Services.Products.Queries.GetProductsForSite;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        IProductFacade _productFacade;
        public ProductsController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }
        public IActionResult Index(OrderBy orderBy,string searchKey,long? catId = null,int page=1, int pageSize=20)
        {
            return View(_productFacade.GetProductsForSite.Execute(orderBy,searchKey ,page,pageSize, catId).Data);
        }

        public IActionResult Details(long id,int page = 1)
        {
            return View(_productFacade.GetProducDetailsForSite.Execute(id).Data);
        }



    }
}
