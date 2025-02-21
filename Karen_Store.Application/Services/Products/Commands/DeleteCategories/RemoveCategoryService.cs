using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Products.Commands.DeleteCategories
{
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _context;
        public RemoveCategoryService(IDataBaseContext Context)
        {
            _context = Context;
        }
        public ResultDto Execute(long Id)
        {
            try
            {
                var result = _context.Categories.Find(Id);
                if (result == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "حذف دسته بندی با خطا مواجه شد"
                    };
                }
                result.IsDeleted = true;
                result.DeleteTime = DateTime.Now;
                result.UpdateDateTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "دسته بندی با موفقیت حذف شد"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
