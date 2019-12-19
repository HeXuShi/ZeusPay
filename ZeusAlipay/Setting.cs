using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusAlipay
{
    internal static class Setting
    {
        private static string SandboxHost => "https://openapi.alipaydev.com/gateway.do";
        private static string ProductHost => "https://openapi.alipay.com/gateway.do";
        private static string _host = null;
        static void Setup()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public static string Host 
        { 
            get 
            { 
                if(_host == null)
                {
                    UseSandboxEnv();
                }
                return _host; 
            } 
        }
        public static void UseSandboxEnv()
        {
            Setup();
            _host = SandboxHost;
        }
        public static void UseProductEnv()
        {
            Setup();
            _host = ProductHost;
        }
    }
}
