using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZeusAlipay.Util;

namespace ZeusAlipay.AuthToken
{
    public static class AuthTokenRequest
    {
        public static string authorization_code => "authorization_code";
        public static string refresh_token => "refresh_token";
        public static async Task<AuthTokenResult> Request(this AlipayClient client, AuthTokenArg arg)
        {
            string text = JsonConvert.SerializeObject(arg);
            var http = new HttpClient();
            var response = await http.PostAsync(client.Host, new StringContent(text));
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthTokenResult>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
