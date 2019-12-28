using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Text;
using ZeusAlipay.Util;
namespace ZeusAlipay.Tests
{
    [TestFixture]
    public class SignTest
    {
        [Test]
        public void RSA2SignTest()
        {
            string checkSignText = "N4rkiV/2bEI2Ji2KaaTDeP8WAsF49+iHVWPV7HKnc/I35x2eySGGmbcAtX3YqUDwtPtTbMIlVDm9e9lQTNz0z6ylq/w1pLbyry5Nr97VJzkHTMkf4YYwFR1KopPvk+ICyZEQLP4I02SlTipZ4easanehVG5n5lyCG894T7v6WgLT0VeL+YeE/6h4CuWgB5V13GxZhT0Yv5e8gNHnTudrrdlaIvE47FrqD9FbxXBV7vBleYmU7bn8liZnIz9DJKxrPSV+tvIheJJE6yf6rXfWoOK0hLanGArOUOWfjJha8KOvDrbTHd9X2sBxlk34BZbJysZnSiSItk50ikTL+/98pg==";
            string text = "app_auth_token=&app_id=2019121860002580&charset=utf-8&format=JSON&method=alipay.trade.precreate&timestamp=2019-12-26 22:13:22&version=1.0&biz_content={  \"out_trade_no\": \"093074c52de44ad2bc96cd3d81af1080\",  \"total_amount\": 1.0,  \"subject\": \"Preceate Test093074c52de44ad2bc96cd3d81af1080\",  \"seller_id\": null,  \"discountable_amount\": null,  \"undiscountable_amount\": null,  \"buyer_logon_id\": null,  \"goods_detail\": null,  \"body\": null,  \"product_code\": null,  \"operator_id\": null,  \"store_id\": null,  \"disable_pay_channels\": null,  \"enable_pay_channels\": null,  \"terminal_id\": null,  \"extend_params\": null,  \"timeout_express\": null,  \"royalty_info\": null,  \"settle_info\": null,  \"sub_merchant\": null,  \"alipay_store_id\": null,  \"merchant_order_no\": null,  \"ext_user_info\": null,  \"business_params\": null,  \"qr_code_timeout_express\": null}&sign_type=RSA2&sign=WiuQItk6a/XrCI2LSt+fvY1VGwdDAHVH4poo9IMYOpWs24KeKyfq2wPEvdbBBd/F1Oto/wD8FYatdrYSNK82XvJ/nbUD2/oxrBsr8Q9pkUJHqvAhm3z7p2aZZQptpqzcUx+WFwPF6YsgbOPdpe7HKf7G9Jn89Haz5mruLfu+zOPTRPCHErXgRGMW7ctBInnI3+u1ZmJKRp4W3gd6YtU9DZXWQWR4ar+UJdhCDLppLM+6pvQyRYacPDUzEUR17EQklNvStpw9xYOyolrRatRLbMpGbB5wTXjolAE3fq1U28J4+vVm0edfs4UBxdF8zs90mEMAf8EJ3BbLL4mogBc7tQ==";
            string pattern = "(?:^|&)[a-zA-Z_]+=(?=&|$)";
            Regex rgx = new Regex(pattern);
            text = rgx.Replace(text, "");
            var queryString = HttpUtility.ParseQueryString(text);
            queryString.Remove("sign");
            queryString.Remove("biz_content");
            var orderedKeys = queryString.Cast<string>().Where(k => k != null).OrderBy(k => k);
            text = string.Join("&", orderedKeys.Select(k => string.Format("{0}={1}", k, queryString[k])));
            string signText = AlipaySignature.RSASignCharSet(text, @"D:\Programing\Dev Repos\ZeusPay\alipayPrivateKey.txt", "utf-8", "RSA2");
            //Assert.AreEqual(signText, checkSignText);
        }
    }
}
