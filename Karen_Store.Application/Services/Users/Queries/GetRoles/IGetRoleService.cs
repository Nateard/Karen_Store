using Karen_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRoleService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
