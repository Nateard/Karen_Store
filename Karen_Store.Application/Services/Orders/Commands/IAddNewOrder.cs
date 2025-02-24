using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Orders;
using Karen_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.Orders.Commands
{
    public interface IAddNewOrder
    {
        ResultDto Execute(RequestAddNewOrderDto request);
    }
    public class AddNewOrder : IAddNewOrder
    {
        private readonly IDataBaseContext _context;
        public AddNewOrder(IDataBaseContext context)
        {
                _context = context;
        }
        public ResultDto Execute(RequestAddNewOrderDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var requestPay = _context.RequestPays.Find(request.RequestPayId);
            var cart = _context.Carts
                .Include(p => p.CartItems)
                .ThenInclude(p=> p.Product)
                .Where(p => p.Id == request.CartId).FirstOrDefault();
            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.RefId = requestPay.RefId;
            requestPay.Authority = requestPay.Authority;
            cart.IsFinished = true;
            Order order = new Order()
            {
                Address = "",
                OrderState = OrderState.Proccesing,
                RequestPay = requestPay,
                User = user,
            };

            _context.Orders.Add(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Order = order,
                    Count = item.Count,
                    Price = item.Product.Price,
                    Product = item.Product,               
               };
                orderDetails.Add(orderDetail);
            }
            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "سفارش شما با موفقیت ثبت شد"
            };

        }
    }
    public class RequestAddNewOrderDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;

    }
}
