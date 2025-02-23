using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
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
            var userId = _context.Users.Find(request.UserId);
            return new ResultDto
            {

            };
        }
    }
    public class RequestAddNewOrderDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }

    }
}
