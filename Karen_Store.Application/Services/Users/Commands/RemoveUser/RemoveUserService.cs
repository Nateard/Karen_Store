using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;
        public RemoveUserService(IDataBaseContext context)
        {
                _context = context;
        }
        public ResultDto Execute(long UserId)
        {
            try
            {
                var user = _context.Users.Find(UserId);
                if (user == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد"
                    };
                }
                user.DeleteTime = DateTime.Now;
                user.IsDeleted = true;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت حذف شد"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
