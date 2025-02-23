using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Finance.Command.AddRequestPay;
using Karen_Store.Application.Services.Finance.Queries;
using Karen_Store.Application.Services.PaymentServices;

namespace Karen_Store.Application.Services.Finance.FacadePattern
{
    public class FinanceFacade : IFinanceFacade
    {
        private readonly IDataBaseContext _context;
        public FinanceFacade(IDataBaseContext context)
        {
            _context = context;
        }
        private IAddRequestPayService _addRequestPayService;
        public IAddRequestPayService AddRequestPayService =>
            _addRequestPayService ?? new AddRequestPayService(_context);


        private IGetRequestPayService _getRequestPayService;
        public IGetRequestPayService GetRequestPayService =>
            _getRequestPayService ?? new GetRequestPayService(_context);

     
    }
}
