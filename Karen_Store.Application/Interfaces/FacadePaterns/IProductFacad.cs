using Karen_Store.Application.Services.Products.Commands.AddNewCategory;
using Karen_Store.Application.Services.Products.Commands.DeleteCategories;
using Karen_Store.Application.Services.Products.Commands.EditCategories;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Interfaces.FacadPaterns
{
    public interface IProductFacade
    {
        IAddNewCategoryServices AddNewCategoryService { get; }
        IGetCategoriesServices GetCategoriesService { get; }
        IRemoveCategoryService RemoveCategoryService { get; }
        IEditCategory EditCategory { get; } 

    }
}
