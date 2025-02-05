using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Validation.CategoryValidation;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Product;

namespace Karen_Store.Application.Services.Products.Commands.AddNewCategory
{
    public partial class AddNewCategoryServices : IAddNewCategoryServices
    {
        private readonly IDatabaseContext _context;
        public AddNewCategoryServices(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(AddNewCategoryDto request)
        {
            var validator = new RequestAddCategoryValidation();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = string.Join(", ", errorMessages)
                };
            }
            Category category = new Category()
            {
                Name = request.Name,
                InsertDateTime = DateTime.Now,
                ParentCategory = GetParent(request.ParentId)
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };
        }
        private Category GetParent(long? parentId)
        {
            return _context.Categories.Find(parentId);
        }
    }
}
