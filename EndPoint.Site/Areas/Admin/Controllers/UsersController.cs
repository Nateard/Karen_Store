using Karen_Store.Application.Services.Users.Commands.RegisterUser;
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
        private readonly IRegisterUserServices _registeredServices;
        public UsersController(IGetUserService getUserService, IGetRoleService getRoleService, IRegisterUserServices registerUserServices)
        {
            _getUserService = getUserService;
            _getRoleService = getRoleService;
            _registeredServices = registerUserServices;
        }

        public IActionResult Index(string searchKey, int page)
        {
            return View(_getUserService.Execute(new RequestGetUserDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRoleService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Email, string Name, string LastName, Guid RoleId, string Password, string RePassword)
        {
            var result = _registeredServices.Execute(new RequestRegisterUserDto
            {
                Password = Password,
                RePassword = RePassword,
                Email = Email,
                Name = Name,
                LastName = LastName,
                Roles = new List<RolesInRegistrationDto>
                {
                new RolesInRegistrationDto
                {
                    Id = RoleId
                }
                }
            });
            if (result.Data != null)
            {
                return Json(new { Success = false, Message = "Registration failed." });
            }
            return Json(result);
        }

    }
}
