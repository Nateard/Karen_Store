using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Products.Commands.EditCategories
{
    public partial class EditCategoryService : IEditCategoryService
    {
        private readonly IDataBaseContext _context;
        public EditCategoryService(IDataBaseContext Context)
        {
            _context = Context;
        }
        public ResultDto Execute(EditCategoryDto input)
        {
            try
            {
                var Category = _context.Categories.Find(input.Id);
                if (Category == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = $"دسته بندی یافت نشد"
                    };
                }
                Category.Name = input.Name;
                Category.UpdateDateTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "دسته بندی با موفقیت ویرایش شد"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
