using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Karen_Store.Domain.Entities.Orders;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class OrdersController : Controller
    {

        private readonly IGetOrdersForAdminService _getOrdersForAdminService;
        public OrdersController(IGetOrdersForAdminService GetOrdersForAdminService)
        {
            _getOrdersForAdminService = GetOrdersForAdminService;
        }
        public IActionResult Index(OrderState  orderState)
        {

            var result = _getOrdersForAdminService.Execute(orderState).Data;

            return View(result);
        }
    }
}
