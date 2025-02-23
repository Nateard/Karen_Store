using Karen_Store.Application.Services.PaymentServices.PaymrntRequest;

namespace Karen_Store.Application.Services.PaymentServices.FacadePatterns
{
    public interface IPaymentproviderFacade
    {
        IPaymentStrategy<ZarinplaPaymentRequestDto> Zarinpal { get; }
    }
    public class PaymentProviderFacade : IPaymentproviderFacade
    {
        public IPaymentStrategy<ZarinplaPaymentRequestDto> Zarinpal =>
            new PaymentStrategy();
    }
}
