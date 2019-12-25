using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZeusPaypal.Orders.Models;
namespace ZeusPaypal.Orders
{
    public static class CreateOrderRequest
    {
        public static async Task<CreateOrderResult> Request(CreateOrderArg arg)
        {
            string text = JsonConvert.SerializeObject(arg);
            var client = new HttpClient();
            var response = await client.PostAsync(Setting.Host + "/v2/checkout/orders", new StringContent(text));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CreateOrderResult>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
