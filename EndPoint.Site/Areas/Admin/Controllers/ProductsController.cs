using Karen_Store.Application.Interfaces.FacadPaterns;
using Karen_Store.Application.Services.Products.Commands.AddNewProduct;
using Karen_Store.Application.Services.Products.Queries.GetAllCategories;
using Karen_Store.Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {

        private readonly IProductFacade _productFacade;

        public ProductsController(IProductFacade productFacad)
        {
            _productFacade = productFacad;
        }
        public IActionResult Index(int Page = 1, int PageSize = 20)
        {
            return View(_productFacade.GetProductForAdmin.Execute(Page, PageSize).Data);
        }

        public IActionResult Detail(long Id)
        {
            return View(_productFacade.GetProductDetailForSiteService.Execute(Id).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            var result = _productFacade.GetAllCategories.Execute(); 
            var categories = result?.Data ?? new List<AllCategoriesDto>(); 
            ViewBag.Categories = new MultiSelectList(categories, "Id", "Name");
            return View();
           
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddProductDto request, List<AddNewProduct_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_productFacade.AddNewProductService.Execute(request));
        }
    }
}
