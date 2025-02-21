using Dto.Payment;
using EndPoint.Site.Utilities;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Carts;
using Karen_Store.Application.Services.Finance.Command.AddRequestPay;
using Karen_Store.Application.Services.PaymentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Common;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize("Customer")]

    public class PayController : Controller
    {
        private readonly IPaymentFacade _paymentFacade;
        private readonly ICartServices _cartService;
        private readonly CookiesManager _cookiesManager;
        private readonly IPaymentproviderFacade _zarinPalProvider;
        //private readonly Payment _payment;
        //private readonly Authority _authority;
        //private readonly Transactions _transactions;
        //private readonly IGetRequestPayService _getRequestPayService;
        //private readonly IAddNewOrderService _addNewOrderService;


        public PayController(
             ICartServices cartService, IPaymentFacade paymentFacade, IPaymentproviderFacade zarinPalProvider
             )
        {
            _paymentFacade = paymentFacade;
            _cartService = cartService;
            _cookiesManager = new CookiesManager();
            _zarinPalProvider = zarinPalProvider;
            //var expose = new Expose();
            //_payment = expose.CreatePayment();
            //_authority = expose.CreateAuthority();
            //_transactions = expose.CreateTransactions();
        }

        public async Task<IActionResult> Index()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), UserId);
            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _paymentFacade.AddRequestPayService.Execute(cart.Data.SumAmount, UserId.Value);
                ZarinplaPaymentRequestDto zarinplaPaymentRequestDto = new ZarinplaPaymentRequestDto()
                {
                    Amount = requestPay.Data.Amount,
                    CallbackUrl = Url.Action(nameof(Verify), "Pay", new { merchantRefrence = requestPay.Data.guid }, Request.Scheme),
                    Description = $" پرداخت فاکتور شماره{requestPay.Data.RequestPayId}",
                    Email = requestPay.Data.Email,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                    Mobile = "09123551266",
                };
                // ارسال در گاه پرداخت
                var result = await _zarinPalProvider.Zarinpal.Execute(zarinplaPaymentRequestDto);
                //var result = await _payment.Request(new ZarinPal.Class.Authority()
                //{
                //    Mobile = "09121112222",
                //    CallbackUrl = "https://localhost:44381/Pay/Verify",
                //    Description = "پرداخت فاکتور شماره:",
                //    Email = "sasasasa@gmail.com",
                //    Amount = 10000000,
                //    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                //}, ZarinPal.Class.Payment.Mode.sandbox);
                //return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Data}");

            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }

        public async Task<IActionResult> Verify()
        {
            return View();
        }
    }
}

