using Karen_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Users.Commands.UserStatusChange
{
    public interface IChangeUserStatus
    {
        ResultDto Execute(long userId);

    }
}
