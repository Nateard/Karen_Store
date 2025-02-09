using Karen_Store.Application.Services.Common.Queries.GetCategory;
using Karen_Store.Application.Services.Common.Queries.GetMenuItem;
using Karen_Store.Application.Services.Products.Commands.AddNewCategory;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Interfaces.FacadePaterns
{
    public interface ICommonFacade
    {
        IGetMenuItemService GetMenuItemService { get; }
        IGetCategoryService GetCategoryService { get; }
    }
}
