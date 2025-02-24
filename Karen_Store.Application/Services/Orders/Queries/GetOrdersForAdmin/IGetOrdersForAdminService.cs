using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState);
    }
}
