using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusAlipay
{
    internal static class Setting
    {
        private static string SandboxHost => "https://openapi.alipaydev.com/gateway.do";
        private static string ProductHost => "https://openapi.alipay.com/gateway.do";
        private static string _host = "https://openapi.alipaydev.com/gateway.do";
        public static string Host { get { return _host; } }
        public static void UseSandboxEnv()
        {
            _host = SandboxHost;
        }
        public static void UseProductEnv()
        {
            _host = ProductHost;
        }
    }
}
