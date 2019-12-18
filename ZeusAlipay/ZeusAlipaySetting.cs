using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusAlipay
{
    public static class ZeusAlipaySetting
    {
        public static void UseSandboxEnv()
        {
            Setting.UseSandboxEnv();
        }
        public static void UseProductEnv()
        {
            Setting.UseProductEnv();
        }
    }
}
