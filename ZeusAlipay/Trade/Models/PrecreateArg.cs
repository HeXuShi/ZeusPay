using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ZeusAlipay.Util;

namespace ZeusAlipay.Trade.Models
{
    public class PrecreateArg : BaseAlipayArg
    {
        [JsonProperty("bizContent")]
        public PrecreateContent BizContent { get; set; }
        public PrecreateArg()
        {
            base._method = "alipay.trade.precreate";
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
    public class PrecreateContent
    {
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        [JsonProperty("total_amount")]
        public double TotalAmount { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("seller_id")]
        public string SellerId { get; set; }

        [JsonProperty("discountable_amount")]
        public string DiscountableAmount { get; set; }

        [JsonProperty("undiscountable_amount")]
        public string UndiscountableAmount { get; set; }

        [JsonProperty("buyer_logon_id")]
        public string BuyerLogonId { get; set; }

        [JsonProperty("goods_detail")]
        public string GoodsDetail { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("operator_id")]
        public string OperatorId { get; set; }

        [JsonProperty("store_id")]
        public string StoreId { get; set; }

        [JsonProperty("disable_pay_channels")]
        public string DisablePayChannels { get; set; }

        [JsonProperty("enable_pay_channels")]
        public string EnablePayChannels { get; set; }

        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }

        [JsonProperty("extend_params")]
        public string ExtendParams { get; set; }

        [JsonProperty("timeout_express")]
        public string TimeoutExpress { get; set; }

        [JsonProperty("royalty_info")]
        public string RoyaltyInfo { get; set; }

        [JsonProperty("settle_info")]
        public string SettleInfo { get; set; }

        [JsonProperty("sub_merchant")]
        public string SubMerchant { get; set; }

        [JsonProperty("alipay_store_id")]
        public string AlipayStoreId { get; set; }

        [JsonProperty("merchant_order_no")]
        public string MerchantOrderNo { get; set; }

        [JsonProperty("ext_user_info")]
        public string ExtUserInfo { get; set; }

        [JsonProperty("business_params")]
        public string BusinessParams { get; set; }

        [JsonProperty("qr_code_timeout_express")]
        public string QrCodeTimeoutExpress { get; set; }
    }
}
