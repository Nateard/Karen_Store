using Karen_Store.Application.Services.Users.Commands.EditUser;
using Karen_Store.Application.Services.Users.Commands.RegisterUser;
using Karen_Store.Application.Services.Users.Commands.RemoveUser;
using Karen_Store.Application.Services.Users.Commands.UserLogin;
using Karen_Store.Application.Services.Users.Commands.UserStatusChange;
using Karen_Store.Application.Services.Users.Queries.GetRoles;
using Karen_Store.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Interfaces.FacadePaterns
{
    public interface IUserFacade
    {
        IGetUserService GetUserService {  get; }    
        IGetRoleService GetRoleService { get; }
        IRegisterUserServices RegisterUserService { get; }
        IRemoveUserService RemoveUserService { get; }
        IChangeUserStatus ChangeUserStatus { get; }
        IEditUserService EditUserService { get; }
        IUserLoginService UserLoginService { get; }
    }
}
