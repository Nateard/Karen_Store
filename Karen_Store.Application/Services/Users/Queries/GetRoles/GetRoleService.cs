using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;

namespace Karen_Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRoleService : IGetRoleService
    {
        private readonly IDatabaseContext _context;
        public GetRoleService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Role.ToList().Select(r => new RolesDto
            {
                Id = r.Id,
                Name = r.Name,
            }).ToList();
            if (!roles.Any())
            {
                return new ResultDto<List<RolesDto>>()
                {
                    Message = "True",
                    Success = false,
                };
            }
            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                Message = "True",
                Success = true,
            };
        }
    }
}
