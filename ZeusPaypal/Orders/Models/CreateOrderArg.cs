using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusPaypal.Orders.Models
{
    public class CreateOrderArg
    {
        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonProperty("purchase_units")]
        public PurchaseUnit[] PurchaseUnits { get; set; }
    }

    public partial class PurchaseUnit
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }

    public partial class Amount
    {
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
