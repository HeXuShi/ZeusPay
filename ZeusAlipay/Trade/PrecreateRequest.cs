using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZeusAlipay.Trade.Models;

namespace ZeusAlipay.Trade
{
    public static class PrecreateRequest
    {
        public static async Task Request(this AlipayClient client, PrecreateArg arg)
        {
            string text = JsonConvert.SerializeObject(arg);
            var http = new HttpClient();
            var response = await http.PostAsync(client.Host, new StringContent(text));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<AuthTokenResult>(content);
            }
            else
            {
                //return null;
            }
        }
    }
}
