using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusAlipay
{
    //EncryptAlgorithm
    //EncryptScheme
    //EncryptMode
    public enum EncryptMode
    {
        RSA2 = 0,
        RSA = 1
    }
    public class AlipayClient
    {
        private string SandboxHost => "https://openapi.alipaydev.com/gateway.do";
        private string ProductHost => "https://openapi.alipay.com/gateway.do";
        private string _host = null;
        public AlipayClient()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public string PrivateKey { get; set; }
        public EncryptMode EncryptMode { get; set; } = EncryptMode.RSA2;
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
            _host = SandboxHost;
        }
        public void UseProductEnv()
        {
            _host = ProductHost;
        }
    }
}
