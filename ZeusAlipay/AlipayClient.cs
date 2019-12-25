using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusAlipay
{
    public class AlipayClient
    {
        private string SandboxHost => "https://openapi.alipaydev.com/gateway.do";
        private string ProductHost => "https://openapi.alipay.com/gateway.do";
        private string _host = null;
        public AlipayClient()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public string Host 
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
        public void UseSandboxEnv()
        {
            Setup();
            _host = SandboxHost;
        }
        public void UseProductEnv()
        {
            Setup();
            _host = ProductHost;
        }
    }
}
