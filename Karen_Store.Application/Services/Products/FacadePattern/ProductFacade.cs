
using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadPaterns;
using Karen_Store.Application.Services.Products.Commands.AddNewCategory;
using Karen_Store.Application.Services.Products.Commands.AddNewProduct;
using Karen_Store.Application.Services.Products.Commands.DeleteCategories;
using Karen_Store.Application.Services.Products.Commands.EditCategories;
using Karen_Store.Application.Services.Products.Queries.GetAllCategories;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
using Karen_Store.Application.Services.Products.Queries.GetProducDetailsForSite;
using Karen_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Karen_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Karen_Store.Application.Services.Products.Queries.GetProductsForSite;
using Microsoft.AspNetCore.Hosting;
namespace Karen_Store.Application.Services.Products.FacadePattern
{
    public class ProductFacade : IProductFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacade(IDataBaseContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;
        }

        private IAddNewCategoryServices _addNewCategory;

        public IAddNewCategoryServices AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryServices(_context);
            }
        }

        private IGetCategoriesServices _getCategoriesService;
        public IGetCategoriesServices GetCategoriesService =>
            _getCategoriesService ??= new GetCategoriesServices(_context);


        private IRemoveCategoryService _removeCategoryService;
        public IRemoveCategoryService RemoveCategoryService =>
            _removeCategoryService ??= new RemoveCategoryService(_context);

        private IEditCategoryService _editCategory;
        public IEditCategoryService EditCategory =>
            _editCategory ??= new EditCategoryService(_context);

        private IAddNewProductService _addNewProduct;
        public IAddNewProductService AddNewProductService =>
            _addNewProduct ??= new AddNewProductService(_context, _environment);


        public IGetAllCategories _getCategories;
        public IGetAllCategories GetAllCategories =>
            _getCategories ??= new GetAllCategories (_context);

        public IGetProductForAdminService _getProductForAdmin;
        public IGetProductForAdminService GetProductForAdmin =>
            _getProductForAdmin ??= new GetProductForAdminService(_context);

        public IGetProductDetailForAdminService _getProductDetailForSiteService;
        public IGetProductDetailForAdminService GetProductDetailForSiteService =>
            _getProductDetailForSiteService ??= new GetProductDetailForAdminService(_context);

        
        public IGetProductsForSite _getProductsForSite;
        public IGetProductsForSite GetProductsForSite =>
            _getProductsForSite ??= new GetProductsForSite(_context);

        public IGetProducDetailsForSite _getProducDetailsForSite;
        public IGetProducDetailsForSite GetProducDetailsForSite =>
            _getProducDetailsForSite ??= new GetProductDetailsForSite (_context);

    }

}
