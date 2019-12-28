using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusAlipay
{
    public abstract class BaseAlipayArg
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
        internal string _method;
        [JsonProperty("method")]
        public string Method { get { return _method; } }
        [JsonProperty("format")]
        public string Format => "JSON";
        [JsonProperty("charset")]
        public string Charset => "GBK";

        //[JsonProperty("sign_type")]
        //public string SignType { get; set; } = "RSA2";
        //[JsonProperty("sign")]
        //public string Sign { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";
        [JsonProperty("app_auth_token")]
        public string AppAuthToken { get; set; }
    }
}
