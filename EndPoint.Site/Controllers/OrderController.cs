using EndPoint.Site.Utilities;
using Karen_Store.Application.Services.Orders.Queries.GetUserOrders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IGetUserOrdersService _getUserOrdersService;
        public OrderController(IGetUserOrdersService getUserOrdersService)
        {
            _getUserOrdersService = getUserOrdersService;
        }
        public IActionResult Index()
        {
            long userId = ClaimUtility.GetUserId(User).Value;
            return View(_getUserOrdersService.Execute(userId).Data);
        }



    }
}
