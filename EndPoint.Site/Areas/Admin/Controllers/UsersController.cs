using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Users.Commands.EditUser;
using Karen_Store.Application.Services.Users.Commands.RegisterUser;
using Karen_Store.Application.Services.Users.Commands.RemoveUser;
using Karen_Store.Application.Services.Users.Commands.UserStatusChange;
using Karen_Store.Application.Services.Users.Queries.GetRoles;
using Karen_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        //private readonly IGetUserService _getUserService;
        //private readonly IGetRoleService _getRoleService;
        //private readonly IRegisterUserServices _registerUserService;
        //private readonly IRemoveUserService _removeUserService;
        //private readonly IChangeUserStatus _changeUserStatus;
        //private readonly IEditUserService _editUserService;
        private readonly IUserFacade _userFacade;
        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public IActionResult Index(string searchKey, int page)
        
        {
            return View(_userFacade.GetUserService.Execute(new RequestGetUserDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }


        [HttpPost]
        public IActionResult Delete(long userId)
        {
            return Json(_userFacade.RemoveUserService.Execute(userId));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_userFacade.GetRoleService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string email, string fullName, int roleId, string password, string rePassword)
        {
            var result = _userFacade.RegisterUserService.Execute(new RequestRegisterUserDto
            {
                Email = email,
                FullName = fullName,
                Roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= roleId
                        }
                   },
                Password = password,
                RePassword = rePassword,
            });
            if (result.Data != null)
            {
                return Json(result);
            }
            return Json(new { Success = false, Message = result.Message });
        }


        [HttpPost]
        public IActionResult StatusChange(long userId)
        {
            return Json(_userFacade.ChangeUserStatus.Execute(userId));
        }



        [HttpPost]
        public IActionResult EditUser(long userId, string fullName, string email)
        {
            return Json(_userFacade.EditUserService.Execute(new RequestEditUserDto
            {
                Email = email,
                FullName = fullName,
                Id = userId
            }));
        }
    }
}
