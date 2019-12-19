using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
namespace ZeusAlipay.Tests
{
    public class AlipayContext
    {
        public string AppId { get; set; }
    }
    public static class Settings
    {
        static string path = @"..\..\..\..\..\setting.json";
        static AlipayContext Config { get; set; } = new AlipayContext();
        static bool isSetup = false;
        public static AlipayContext GetConfig()
        {
            lock(Config)
            {
                if (!isSetup && File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    Config = JsonConvert.DeserializeObject<AlipayContext>(text);
                }
                else
                    throw new InvalidOperationException("Create setting.json fail");
            }
            return Config;
        }
    }
}
