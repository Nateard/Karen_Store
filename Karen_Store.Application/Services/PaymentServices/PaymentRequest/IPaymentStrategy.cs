using Karen_Store.Common.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Karen_Store.Application.Services.PaymentServices.PaymrntRequest
{
    public interface IPaymentStrategy<T>
    {
        bool AppliesTo(string type);
        Task<ResultDto<string>> Execute(T input);
    }
    public class PaymentStrategy : IPaymentStrategy<ZarinplaPaymentRequestDto>
    {
        public bool AppliesTo(string type)
        {
            return type == PaymentConstants.Zarinpal;

        }

        public async Task<ResultDto<string>> Execute(ZarinplaPaymentRequestDto input)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(NetworkConstants.ContentType));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var requestBody = JsonConvert.SerializeObject(input);
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, "https://sandbox.zarinpal.com/pg/v4/payment/request.json");
                request.Content = content;

                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var orderResponse = JsonConvert.DeserializeObject<Root>(responseContent);

                    //return new NetworkResultDto<CreateOrderResponse>
                    //{
                    //    Success = true,
                    //    Data = orderResponse
                    //};
                    return new ResultDto<string>()
                    {
                        IsSuccess = true,
                        Data = orderResponse.data.authority
                    };
                }
                else
                {
                    return new ResultDto<string>();
                    //return new NetworkResultDto<CreateOrderResponse>
                    //{
                    //    Success = false,
                    //    Data = null,
                    //    Message = "Error while creating the order"
                    //};
                }
            }
        }
    }
}
//var result = await _payment.Request(new DtoRequest()
//{
//    Mobile = "09121112222",
//    CallbackUrl = "https://localhost:44381/Pay/Verify",
//    Description = "پرداخت فاکتور شماره:",
//    Email = "sasasasa@gmail.com",
//    Amount = 10000000,
//    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
//}, ZarinPal.Class.Payment.Mode.sandbox);
//return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
public class Data
{
    public string authority { get; set; }
    public int fee { get; set; }
    public string fee_type { get; set; }
    public int code { get; set; }
    public string message { get; set; }
}

public class Root
{
    public Data data { get; set; }
    public List<object> errors { get; set; }
}