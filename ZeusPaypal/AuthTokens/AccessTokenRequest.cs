using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using ZeusPaypal.AuthTokens.Models;
using System.Net.Http.Headers;

namespace ZeusPaypal.AuthTokens
{
    public static class AccessTokenRequest
    {
        public static async Task<AccessTokenResult> GetAccessToken(this PaypayClient client)
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("Accept", " application/json");
            http.DefaultRequestHeaders.Add("Accept-Language", " en_US");

            var authToken = Encoding.ASCII.GetBytes($"{client.ClientId}:{client.Secret}");
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));
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
