using Karen_Store.Application.Services.Users.Commands.RegisterUser;
using Karen_Store.Application.Services.Users.Commands.RemoveUser;
using Karen_Store.Application.Services.Users.Queries.GetRoles;
using Karen_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUserService _getUserService;
        private readonly IGetRoleService _getRoleService;
        private readonly IRegisterUserServices _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        public UsersController(IGetUserService getUserService,
            IGetRoleService getRoleService,
            IRegisterUserServices registerUserServices,
            IRemoveUserService removeUserService)
        {
            _getUserService = getUserService;
            _getRoleService = getRoleService;
            _registerUserService = registerUserServices;
            _removeUserService = removeUserService;
        }

        public IActionResult Index(string searchKey, int page)
        {
            return View(_getUserService.Execute(new RequestGetUserDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }


        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRoleService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Email, string Name, string LastName, int RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                Name = Name,
                LastName = LastName,
                Roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePassword = RePassword,
            });
            if (result.Data != null )
            {
                return Json(result);             
            }
            return Json(new { Success = false, Message = "Registration failed." });
        }

       
    }
}
