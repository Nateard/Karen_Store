using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadPaterns;
using Karen_Store.Application.Services.Products.Commands.AddNewCategory;
using Karen_Store.Application.Services.Products.Commands.DeleteCategories;
using Karen_Store.Application.Services.Products.Commands.EditCategories;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
namespace Karen_Store.Application.Services.Products.FacadPatern
{
    public class ProductFacade : IProductFacade
    {
        private readonly IDatabaseContext _context;
        public ProductFacade(IDatabaseContext context)
        {
            _context = context;
        }

        private IAddNewCategoryServices _addNewCategory;

        public IAddNewCategoryServices AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryServices(_context);
            }
        }

        //public IGetCategoriesServices GetCategoriesService => new GetCategoriesServices(_context);

        private IGetCategoriesServices _getCategoriesService;
        public IGetCategoriesServices GetCategoriesService =>
            _getCategoriesService ??= new GetCategoriesServices(_context);


        private IRemoveCategoryService _removeCategoryService;
        public IRemoveCategoryService RemoveCategoryService =>
            _removeCategoryService ??= new RemoveCategoryService(_context);

        private IEditCategory _editCategory;
        public IEditCategory EditCategory =>
            _editCategory ??= new EditCategory(_context);
    }

}
