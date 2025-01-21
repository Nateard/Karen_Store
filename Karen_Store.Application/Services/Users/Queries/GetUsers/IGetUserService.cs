using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        public ResultGetUserDto Execute(RequestGetUserDto request);
    }
}