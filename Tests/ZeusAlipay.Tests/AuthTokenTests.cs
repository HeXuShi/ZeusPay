﻿using NUnit.Framework;
using System;
using System.Threading.Tasks;
using ZeusAlipay.AuthToken;

namespace ZeusAlipay.Tests
{
    [TestFixture]
    public class AuthTokenTests
    {
        [Test]
        public async Task CreateToken()
        {

            var arg = new AuthTokenArg 
            {
                AppId = Settings.Config.AppId,
                BizContent = new AuthTokenContent
                {
                    GrantType = AuthTokenRequest.authorization_code
                }
            };
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

        }
    }
}
