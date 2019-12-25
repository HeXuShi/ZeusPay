using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusPaypal.Orders.Models
{
    public class CreateOrderResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }
}
