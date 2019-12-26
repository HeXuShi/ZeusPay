﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ZeusAlipay.Trade.Models;
using ZeusAlipay.Trade;
using System.Threading.Tasks;

namespace ZeusAlipay.Tests
{
    [TestFixture]
    public class PrecreateTests
    {
        AlipayContext config;
        [SetUp]
        public void Setup()
        {
            config = Settings.GetConfig();
        }
        [Test]
        public async Task Precreate()
        {
            string orderId = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var content = new PrecreateContent 
            { 
                OutTradeNo = orderId,
                Subject = "Preceate Test" + orderId,
                TotalAmount = 1
            };
            var arg = new PrecreateArg
            {
                AppId = config.AppId,
                BizContent = content
            };
            arg.SetRSA2Sign(@"D:\Programing\Dev Repos\ZeusPay\alipayRootCert.crt");
            var client = new AlipayClient();
            client.UseProductEnv();
            await PrecreateRequest.Request(client, arg);
        }
    }
}
