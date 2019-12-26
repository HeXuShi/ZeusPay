using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZeusAlipay.Trade.Models;

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
            var test = jObj.AsJEnumerable().OrderBy(c => c.ToString());

            var query = String.Join("&",
                           test.Cast<JProperty>()
                            .Select(jp => jp.Name + "=" + jp.Value.ToString()));

            query += "&" + bizContent.ToString().Replace("\r\n", "");
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
