using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
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
using static Karen_Store.Application.Services.Users.Commands.UserLogin.IUserLoginService;

namespace Karen_Store.Application.Services.Users.FacadePattern
{
    public class UserFacade : IUserFacade
    {
        private readonly IDatabaseContext _context;
        public UserFacade(IDatabaseContext context)
        {
            _context = context;
        }
        public IGetUserService _getUserService;
        public IGetUserService GetUserService
        {
            get
            {
                return _getUserService = _getUserService ?? new GetUserService(_context);
            }
        }

        public IGetRoleService _getRoleService;
        public IGetRoleService GetRoleService
        {
            get
            {
                return _getRoleService = _getRoleService ?? new GetRoleService(_context);
            }
        }
        public IRegisterUserServices _registerUserService;
        public IRegisterUserServices RegisterUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserServices(_context);
            }
        }
        public IRemoveUserService _removeUserService;
        public IRemoveUserService RemoveUserService
        {
            get
            {
                return _removeUserService = _removeUserService ?? new RemoveUserService(_context);
            }
        }
        public IChangeUserStatus _changeUserStatus;
        public IChangeUserStatus ChangeUserStatus
        {
            get
            {
                return _changeUserStatus = _changeUserStatus ?? new ChangeUserStatus(_context);
            }
        }
        public IEditUserService _editUserService;
        public IEditUserService EditUserService
        {
            get
            {
                return _editUserService = _editUserService ?? new EditUserService(_context);
            }
        }
        public IUserLoginService _userLoginService; 
        public IUserLoginService UserLoginService
        {
            get
            {
                return _userLoginService = _userLoginService ?? new UserLoginService(_context);
            }
        }
    }
}
