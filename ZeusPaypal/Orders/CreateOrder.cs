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
        public static async Task<CreateOrderResult> CreateOrder(this PaypayClient client, CreateOrderArg arg)
        {
            string text = JsonConvert.SerializeObject(arg);
            var http = new HttpClient();
            var response = await http.PostAsync(client.Host + "/v2/checkout/orders", new StringContent(text));
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
