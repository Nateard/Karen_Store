using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Finance;

namespace Karen_Store.Application.Services.Finance.Command.AddRequestPay
{
    public interface IAddRequestPayService
    {
        ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId);
    }


    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDataBaseContext _context;
        public AddRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.Users.Find(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount,
                Guid = Guid.NewGuid(),
                IsPay = false,
                User = user,
                Authority = ""
            };
            _context.RequestPays.Add(requestPay);
            _context.SaveChanges();

            return new ResultDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto
                {
                    guid = requestPay.Guid,
                    Amount = requestPay.Amount,
                    Email = user.Email,
                    RequestPayId = requestPay.Id,
                },
                IsSuccess = true,
            };
        }
    }

    public class ResultRequestPayDto
    {
        public Guid guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public long RequestPayId { get; set; }
    }
}
