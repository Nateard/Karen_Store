using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Users.Commands.UserStatusChange
{
    public class ChangeUserStatus : IChangeUserStatus
    {
        private readonly IDataBaseContext _context;
        public ChangeUserStatus(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string usetStatus = user.IsActive == true ? "فعال" : "غیرفعال";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {usetStatus} شد"
            };
        }
    }
}
