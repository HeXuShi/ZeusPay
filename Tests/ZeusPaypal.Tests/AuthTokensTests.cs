using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZeusPaypal.AuthTokens.Models;
using ZeusPaypal.AuthTokens;
using ZeusPaypal;
namespace ZeusPaypal.Tests
{
    [TestFixture]
    public class AuthTokensTests
    {
        PaypalContext config;
        [SetUp]
        public void Setup()
        {
            config = Settings.GetConfig();
        }
        [Test]
        public async Task AccessTokenTest()
        {
            var client = new PaypayClient { ClientId = config.ClientId, Secret = config.Secret };
            var result = await client.GetAccessToken();
            Assert.IsNotNull(result);
        }
    }
}
