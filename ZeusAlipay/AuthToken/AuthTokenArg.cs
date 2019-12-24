using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ZeusAlipay.Util;

namespace ZeusAlipay.AuthToken
{
    public class AuthTokenArg : BaseAlipayArg
    {
        [JsonProperty("bizContent")]
        public AuthTokenContent BizContent { get; set; }
        public AuthTokenArg()
        {
            base._method = "alipay.open.auth.token.app";
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public void SetRSA2Sign(string privatePem)
        {
            string text = JsonConvert.SerializeObject(BizContent);
            Sign = AlipaySignature.RSASignCharSet(text, privatePem, "utf-8", "RSA2");
        }
        public void SetRSASign(string privatePem)
        {
            string text = JsonConvert.SerializeObject(BizContent);
            Sign = AlipaySignature.RSASignCharSet(text, privatePem, "utf-8", "RSA");
        }
    }
    public class AuthTokenContent
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
