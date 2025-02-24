using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Karen_Store.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersForAdminService(IDataBaseContext context)
        {
                _context = context;
        }
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders = _context.Orders
                .Include(p => p.OrderDetail)
                .Where(p => p.OrderState == orderState)
                .OrderByDescending(p => p.Id)
                .Select(p => new OrdersDto
                {
                    InsertTime = p.InsertDateTime,
                    OrderId= p.Id,
                    OrderState = p.OrderState,
                    ProductCount = p.OrderDetail.Count,
                    RequestId = p.RequestPayId,
                    UserId = p.UserId,
                }).ToList();
            return new ResultDto<List<OrdersDto>>()
            {
                Data = orders,
                IsSuccess = true ,
                Message = ""
            };
        }
    }

}
