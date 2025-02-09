using Karen_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Karen_Store.Application.Services.Products.Commands.AddNewCategory;
using Karen_Store.Application.Services.Products.Commands.AddNewProduct;
using Karen_Store.Application.Services.Products.Commands.DeleteCategories;
using Karen_Store.Application.Services.Products.Commands.EditCategories;
using Karen_Store.Application.Services.Products.Queries.GetAllCategories;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
using Karen_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Karen_Store.Application.Services.Products.Queries.GetProductsForSite;
using Karen_Store.Application.Services.Products.Queries.GetProducDetailsForSite;

namespace Karen_Store.Application.Interfaces.FacadPaterns
{
    public interface IProductFacade
    {
        IAddNewCategoryServices AddNewCategoryService { get; }
        IGetCategoriesServices GetCategoriesService { get; }
        IRemoveCategoryService RemoveCategoryService { get; }
        IEditCategoryService EditCategory { get; }
        IAddNewProductService AddNewProductService { get; }
        IGetAllCategories GetAllCategories { get; }
        IGetProductForAdminService GetProductForAdmin { get; }
        IGetProductDetailForAdminService GetProductDetailForSiteService { get; }
        IGetProductsForSite GetProductsForSite { get; }

        IGetProducDetailsForSite GetProducDetailsForSite { get; }   
    }
}
