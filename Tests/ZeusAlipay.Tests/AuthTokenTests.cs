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
            arg.SetSign(@"D:\Programing\Dev Repos\ZeusPay\alipayRootCert.crt");
            var result = await AuthTokenRequest.Request(arg);
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
