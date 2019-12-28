using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ZeusAlipay.Trade.Models;
using ZeusAlipay.Trade;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

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
        static string GetMd5Hash(string input)
        {
            byte[] data;
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public string GetCertSN(string path)
        {
            X509Certificate2 x509 = new X509Certificate2(File.ReadAllBytes(path));
            try
            {
                //Create X509Certificate2 object from .cer file.
                string text = x509.IssuerName.Name + x509.SerialNumber;
                return GetMd5Hash(text);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error: The directory specified could not be found.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: A file in the directory could not be accessed.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("File must be a .cer file. Program does not have access to that type of file.");
            }
            return string.Empty;
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
            var client = new AlipayClient();
            client.PrivateKey = @"D:\Programing\Dev Repos\ZeusPay\alipayPrivateKey.txt";
            client.AlipayRootCertSN = GetCertSN(@"D:\Programing\Dev Repos\ZeusPay\alipayRootCert.crt");
            client.AppCertSN = GetCertSN(@"D:\Programing\Dev Repos\ZeusPay\appCertPublicKey.crt");
            client.UseProductEnv();
            await PrecreateRequest.Request(client, arg);
        }
    }
}
