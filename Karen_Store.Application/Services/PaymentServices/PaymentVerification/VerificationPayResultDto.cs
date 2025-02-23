using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Application.Services.PaymentServices.PaymentVerification
{
    //public class VerificationPayResultDto
    //{
    //    public int Status { get; set; }
    //    public int RefID { get; set; }
    //}

    public class VerificationPayResultDto
    {
        [JsonProperty("wages")]
        public object Wages { get; set; }

        [JsonProperty("code")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("card_hash")]
        public string CardHash { get; set; }

        [JsonProperty("card_pan")]
        public string CardPan { get; set; }

        [JsonProperty("ref_id")]
        public int RefId { get; set; }

        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        [JsonProperty("fee")]
        public int Fee { get; set; }

        [JsonProperty("shaparak_fee")]
        public int ShaparakFee { get; set; }

        [JsonProperty("order_id")]
        public object OrderId { get; set; }
    }

   public class VerificationResponseWrapper
    {
        [JsonProperty("data")]
        public VerificationPayResultDto Data { get; set; }

        [JsonProperty("errors")]
        public object Errors { get; set; }
    }
}
