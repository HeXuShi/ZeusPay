using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZeusAlipay.AuthToken
{
    public abstract class AuthTokenExceptionResponse
    {

        [JsonProperty("sub_code")]
        public string SubCode { get; set; }

        [JsonProperty("sub_msg")]
        public string SubMsg { get; set; }
    }
    public abstract class AuthTokenNormalResponse : AuthTokenExceptionResponse
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("auth_app_id")]
        public string AuthAppId { get; set; }

        [JsonProperty("app_auth_token")]
        public string AppAuthToken { get; set; }

        [JsonProperty("app_refresh_token")]
        public string AppRefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("re_expires_in")]
        public long ReExpiresIn { get; set; }
    }

    public class AuthTokenResult
    {
        [JsonProperty("alipay_trade_precreate_response")]
        public AlipayTradePrecreateResponse AlipayTradePrecreateResponse { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }
    }

    public class AlipayTradePrecreateResponse :  AuthTokenNormalResponse
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
