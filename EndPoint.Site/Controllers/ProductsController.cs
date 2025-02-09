using Karen_Store.Application.Interfaces.FacadPaterns;
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
        public IActionResult Index(string searchKey,long? catId = null,int page=1)
        {
            return View(_productFacade.GetProductsForSite.Execute(searchKey ,page , catId).Data);
        }

        public IActionResult Details(long id,int page = 1)
        {
            return View(_productFacade.GetProducDetailsForSite.Execute(id).Data);
        }



    }
}
