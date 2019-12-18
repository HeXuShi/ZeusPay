using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZeusAlipay.AuthToken
{
    public class AuthTokenArg
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        [JsonProperty("method")]
        public string Method => "alipay.open.auth.token.app";
        [JsonProperty("charset")]
        public string Charset => "utf-8";

        [JsonProperty("sign_type")]
        public string SignType => "RSA2";
        [JsonProperty("sign")]
        public string Sign { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("app_auth_token")]
        public string AppAuthToken { get; set; }
        [JsonProperty("bizContent")]
        public AuthTokenContent BizContent { get; set; }
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
