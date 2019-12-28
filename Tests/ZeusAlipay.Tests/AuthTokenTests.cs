using NUnit.Framework;
using System;
using System.Threading.Tasks;
using ZeusAlipay.AuthToken;

namespace ZeusAlipay.Tests
{
    [TestFixture]
    public class AuthTokenTests
    {
        AlipayContext config;
        [SetUp]
        public void Setup()
        {
            config = Settings.GetConfig();
        }
        [Test]
        public async Task CreateToken()
        {
            var content = new AuthTokenContent
            {
                GrantType = AuthTokenRequest.authorization_code
            };

            var arg = new AuthTokenArg
            {
                AppId = config.AppId,
                BizContent = content
            };
            arg.SetRSA2Sign(@"D:\Programing\Dev Repos\ZeusPay\alipayPrivateKey.txt");
            var client = new AlipayClient();
            var result = await AuthTokenRequest.Request(client, arg);
            Assert.IsNotNull(result);
            if(result != null)
            {
                Assert.AreEqual(result.AlipayTradePrecreateResponse.Code, 10000);
            }
        }
        [Test]
        public void RefreshToken()
        {
            Assert.True(true);
        }
    }
}
