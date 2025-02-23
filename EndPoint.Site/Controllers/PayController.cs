using EndPoint.Site.Utilities;
using Karen_Store.Application.Interfaces.FacadePaterns;
using Karen_Store.Application.Services.Carts;
using Karen_Store.Application.Services.PaymentServices.FacadePatterns;
using Karen_Store.Application.Services.PaymentServices.PaymentVerification;
using Karen_Store.Application.Services.PaymentServices.PaymrntRequest;
using Karen_Store.Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize("Customer")]

    public class PayController : Controller
    {
        private readonly IFinanceFacade _financeFacade;
        private readonly ICartServices _cartService;
        private readonly CookiesManager _cookiesManager;
        private readonly IPaymentproviderFacade _zarinPalProvider;
        //private readonly Payment _payment;
        //private readonly Authority _authority;
        //private readonly Transactions _transactions;
        //private readonly IGetRequestPayService _getRequestPayService;
        //private readonly IAddNewOrderService _addNewOrderService;


        public PayController(
             ICartServices cartService, IFinanceFacade financeFacade, IPaymentproviderFacade zarinPalProvider
             )
        {
            _financeFacade = financeFacade;
            _cartService = cartService;
            _cookiesManager = new CookiesManager();
            _zarinPalProvider = zarinPalProvider;
            //var expose = new Expose();
            ////_payment = expose.CreatePayment();
            //_authority = expose.CreateAuthority();
            //_transactions = expose.CreateTransactions();
        }

        public async Task<IActionResult> Index()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            ResultDto<CartDto>? cart = null;

            if (UserId == null)
            {
                cart = _cartService.GetMyCartByBrowserId(_cookiesManager.GetBrowserId(HttpContext));
            }
            else
            {
                 cart = _cartService.GetMyCartByUserId(UserId);
            }
            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _financeFacade.AddRequestPayService.Execute(cart.Data.SumAmount, UserId.Value);
                ZarinplaPaymentRequestDto zarinplaPaymentRequestDto = new ZarinplaPaymentRequestDto()
                {
                    Amount = requestPay.Data.Amount,
                    CallbackUrl = Url.Action(nameof(Verify), "Pay", new { merchantReference = requestPay.Data.guid }, Request.Scheme),
                    Description = $" پرداخت فاکتور شماره{requestPay.Data.RequestPayId}",
                    Email = requestPay.Data.Email,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                    Mobile = "09123551266",
                };
                var result = await _zarinPalProvider.Zarinpal.Execute(zarinplaPaymentRequestDto);
                #region zarinpal library
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
                #endregion
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Data}");
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }

        public async Task<IActionResult> Verify(Guid merchantReference, string authority, string status)
        {
            try
            {
                var requestPay = _financeFacade.GetRequestPayService.Execute(merchantReference);

                // URL جدید زرین‌پال
                var options = new RestClientOptions("https://sandbox.zarinpal.com/pg/v4/payment/verify.json")
                {
                    ThrowOnAnyError = true,
                    MaxTimeout = 50000 // زمان تایم‌اوت جدید
                };

                var client = new RestClient(options);
                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                // درخواست ارسال شده به زرین‌پال
                var body = new
                {
                    authority = authority,
                    merchant_id = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX", // شماره مرچنت درست را جایگزین کنید
                    amount = requestPay.Data.Amount
                };

                request.AddJsonBody(body);

                var response = await client.ExecuteAsync(request);

                // بررسی وضعیت پاسخ از زرین‌پال
                if (!response.IsSuccessful)
                {
                    return BadRequest(new { message = "خطا در ارسال درخواست به زرین‌پال", status = response.StatusCode, error = response.Content });
                }

                // دسیریالایز کردن پاسخ به مدل مناسب
                var responseWrapper = JsonConvert.DeserializeObject<VerificationResponseWrapper>(response.Content);

                if (responseWrapper == null || responseWrapper.Data == null)
                {
                    return StatusCode(500, new { message = "پاسخ نامعتبر از زرین‌پال دریافت شد" });
                }

                var verificationResult = responseWrapper.Data;

                // بررسی نتیجه پرداخت
                if (verificationResult.Status == 100 || verificationResult.Status == 101) // 100 و 101 به معنی موفقیت پرداخت هستند
                {
                    return Ok(verificationResult);
                }
                else
                {
                    return BadRequest(new { message = "پرداخت ناموفق بود", status = verificationResult.Status });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "خطای داخلی سرور", error = ex.Message });
            }
        }
    }
}

