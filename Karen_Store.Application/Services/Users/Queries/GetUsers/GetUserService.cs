using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common;

namespace Karen_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUserService : IGetUserService
    {
        private readonly IDatabaseContext _context;
        public GetUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                users = _context.Users.Where(p=>
                    p.Name.Contains(request.SearchKey) ||
                    p.LastName.Contains(request.SearchKey) ||
                    p.Email.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var result = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Name = p.Name,
                LastName = p.LastName,
                Email = p.Email,
            }).ToList();
            if (!result.Any())
            {

            }
            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = result,
            };
        }
    }
}