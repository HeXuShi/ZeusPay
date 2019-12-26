using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using ZeusAlipay.Trade.Models;
using ZeusAlipay.Util;

namespace ZeusAlipay.Trade
{
    public static class PrecreateRequest
    {
        public static async Task<PrecreateResult> Request(this AlipayClient client, PrecreateArg arg)
        {
            string text = JsonConvert.SerializeObject(arg);
            var jObj = (JObject)JsonConvert.DeserializeObject(text);
            JToken bizContent;
            if(!jObj.TryGetValue("bizContent", out bizContent))
            {
                return null;
            }
            jObj.Remove("bizContent");

            var query = String.Join("&",
                           jObj.Children().Cast<JProperty>()
                           .OrderBy(c => c.Name)
                           .Select(jp => jp.Name + "=" + jp.Value.ToString()));

            List<JToken> removeTokens = new List<JToken>();
            foreach(var item in bizContent.Children().Cast<JProperty>())
            {
                if(string.IsNullOrWhiteSpace(item.Value.ToString()))
                {
                    removeTokens.Add(item);
                }
            }
        
            foreach(var item in removeTokens)
            {
                item.Remove();
            }

            query += "&biz_content=" + bizContent.ToString().Replace("\r\n", "");
            string pattern = "(?:^|&)[a-zA-Z_]+=(?=&|$)";
            if (client.EncryptMode == EncryptMode.RSA2)
            {
                query += "&sign_type=RSA2";
            }
            else if (client.EncryptMode == EncryptMode.RSA)
            {
                query += "&sign_type=RSA";
            }
            Regex rgx = new Regex(pattern);
            text = rgx.Replace(query, "");
            var queryString = HttpUtility.ParseQueryString(text);
            queryString.Remove("sign");
            //queryString.Remove("biz_content");
            var orderedKeys = queryString.Cast<string>().Where(k => k != null).OrderBy(k => k);
            text = string.Join("&", orderedKeys.Select(k =>
            {
                if (k != "timestamp")
                {
                    return string.Format("{0}={1}", k, queryString[k].Replace(" ", ""));
                }
                else
                    return string.Format("{0}={1}", k, queryString[k]);

            }
            ));
            text = text.Replace(" \"", "");
            if (client.EncryptMode == EncryptMode.RSA2)
            {
                string sign = AlipaySignature.RSASignCharSet(HttpUtility.HtmlEncode(text), client.PrivateKey, "utf-8", "RSA2");
                query = text + $"&sign={sign}";
            }
            else if (client.EncryptMode == EncryptMode.RSA)
            {
                string sign = AlipaySignature.RSASignCharSet(HttpUtility.HtmlEncode(text), client.PrivateKey, "utf-8", "RSA");
                query = text + $"&sign={sign}";
            }
            queryString = HttpUtility.ParseQueryString(query);
            query = string.Join("&", queryString.Cast<string>().Select(k => string.Format("{0}={1}", k, HttpUtility.UrlEncode(queryString[k]))));

            //.Select(jp => jp.Name + "=" + HttpUtility.UrlEncode(jp.Value.ToString())));
            var http = new HttpClient();
            var response = await http.GetAsync(client.Host + "?" + query);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PrecreateResult>(content);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return null;
            }
        }
    }
}
