using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace ZeusPaypal.AuthTokens
{
    public static class AccessToken
    {
        public static async Task AccessTokenRequest(this PaypayClient client)
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("Accept", " application/json");
            http.DefaultRequestHeaders.Add("Accept-Language", " en_US");
            http.DefaultRequestHeaders.Add(client.ClientId, client.Secret);
            var response = await http.PostAsync(client.Host + "/v1/oauth2/token", new StringContent("grant_type=client_credentials"));
            if(response.StatusCode == HttpStatusCode.OK)
            {
               
            }
            else
            {
                //return null;
            }
        }
    }
}
