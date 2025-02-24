using EndPoint.Site.Models.ViewModels.Common.CategoriesVeiwModel;
using Karen_Store.Application.Interfaces.FacadPaterns;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
using Karen_Store.Domain.Entities.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using static Karen_Store.Application.Services.Products.Commands.AddNewCategory.AddNewCategoryServices;
using static Karen_Store.Application.Services.Products.Commands.EditCategories.EditCategoryService;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {       
        private readonly IProductFacade _productFacade;
        public CategoriesController(IProductFacade productFacade)
        {
                _productFacade = productFacade;
        }
        public IActionResult Index(long? parentId)
        {
            var result = _productFacade.GetCategoriesService.Execute(parentId);
            var viewModel = new IndexCategoriesViewModel
            {
                Categories = result.Data 
            };
            return View(viewModel); 

        }
        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();  
        }

        [HttpPost]
        public IActionResult AddNewCategory(AddNewCategoryDto category)
        {
            var result = _productFacade.AddNewCategoryService.Execute(category);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            return Json(_productFacade.RemoveCategoryService.Execute(id));
        }

        [HttpPost]
        public IActionResult EditCategory(EditCategoryDto input)
        {
            return Json(_productFacade.EditCategory.Execute(input));
        }
    }
}
