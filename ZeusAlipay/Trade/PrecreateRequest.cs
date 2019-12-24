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
    public class PrecreateRequest
    {
        public static async Task Request(PrecreateArg arg)
        {
            string text = JsonConvert.SerializeObject(arg);
            var client = new HttpClient();
            var response = await client.PostAsync(Setting.Host, new StringContent(text));
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
