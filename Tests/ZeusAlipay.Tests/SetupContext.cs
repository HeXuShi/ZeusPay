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
        public static AlipayContext Config { get; set; } = null;
        [SetUp]
        public static void Setup()
        {
            lock(Config)
            {
                if(Config == null)
                {
                    if(File.Exists(path))
                    {
                        string text = File.ReadAllText(path);
                        Config = JsonConvert.DeserializeObject<AlipayContext>(text);
                    }
                }
            }
        }
    }
}
