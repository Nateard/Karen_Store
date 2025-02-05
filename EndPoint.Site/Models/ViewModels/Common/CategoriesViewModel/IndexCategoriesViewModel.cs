using Karen_Store.Application.Services.Products.Commands.DeleteCategories;
using Karen_Store.Application.Services.Products.Commands.EditCategories;
using Karen_Store.Application.Services.Products.Queries.GetCategories;
using Karen_Store.Common.Dto;

namespace EndPoint.Site.Models.ViewModels.Common.CategoriesVeiwModel
{
    public class IndexCategoriesViewModel
    {

        public List<GetCategoryDto> Categories { get; set; }

    }
}
