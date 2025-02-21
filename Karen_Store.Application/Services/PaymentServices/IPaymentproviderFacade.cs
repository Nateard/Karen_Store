namespace Karen_Store.Application.Services.PaymentServices
{
    public interface IPaymentproviderFacade
    {
        IPaymentStrategy<ZarinplaPaymentRequestDto> Zarinpal { get; }
    }
    public class PaymentproviderFacade : IPaymentproviderFacade
    {
        public IPaymentStrategy<ZarinplaPaymentRequestDto> Zarinpal =>
            new PaymentStrategy();
    }
}
