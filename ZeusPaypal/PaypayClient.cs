using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusPaypal
{
    public class PaypayClient
    {
        private string SandboxHost => "https://api.sandbox.paypal.com";
        private string ProductHost => "https://api.paypal.com";
        private string _host = null;
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Host
        {
            get
            {
                if (_host == null)
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
