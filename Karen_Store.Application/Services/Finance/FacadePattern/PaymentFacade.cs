using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Finance.Command.AddRequestPay;

namespace Karen_Store.Application.Services.Finance.FacadePattern
{
    public class PaymentFacade : IPaymentFacade
    {
        private readonly IDataBaseContext _context;
        public PaymentFacade(IDataBaseContext context)
        {
            _context = context;
        }
        private IAddRequestPayService _addRequestPayService;
        public IAddRequestPayService AddRequestPayService =>
            _addRequestPayService ?? new AddRequestPayService(_context);
    }
}
