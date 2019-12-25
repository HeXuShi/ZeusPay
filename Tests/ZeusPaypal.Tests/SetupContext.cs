using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZeusPaypal.Tests
{
    public class PaypalContext
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
    }
    public static class Settings
    {
        static string path = @"..\..\..\..\..\paypal.setting.json";
        static PaypalContext Config { get; set; } = new PaypalContext();
        static bool isSetup = false;
        public static PaypalContext GetConfig()
        {
            lock (Config)
            {
                if (!isSetup && File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    Config = JsonConvert.DeserializeObject<PaypalContext>(text);
                }
                else
                    throw new InvalidOperationException("Create setting.json fail");
            }
            return Config;
        }
    }
}
