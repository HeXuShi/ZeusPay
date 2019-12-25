using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using ZeusPaypal.AuthTokens.Models;
namespace ZeusPaypal.AuthTokens
{
    public static class AccessTokenRequest
    {
        public static async Task<AccessTokenResult> GetAccessToken(this PaypayClient client)
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("Accept", " application/json");
            http.DefaultRequestHeaders.Add("Accept-Language", " en_US");
            http.DefaultRequestHeaders.Add(client.ClientId, client.Secret);
            var response = await http.PostAsync(client.Host + "/v1/oauth2/token", new StringContent("grant_type=client_credentials"));
            if(response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AccessTokenResult>(content);
                client.AccessToken = result.AccessToken;
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
