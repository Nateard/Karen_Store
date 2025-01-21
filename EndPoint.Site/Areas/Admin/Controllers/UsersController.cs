using Karen_Store.Application.Services.Users.Queries.GetRoles;
using Karen_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUserService _getUserService;
        private readonly IGetRoleService _getRoleService;
        public UsersController(IGetUserService getUserService, IGetRoleService getRoleService)
        {
            _getUserService = getUserService;
            _getRoleService = getRoleService;
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

    }
}
