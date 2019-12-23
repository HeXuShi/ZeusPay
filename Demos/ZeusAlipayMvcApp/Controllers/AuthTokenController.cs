using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZeusAlipayMvcApp.Controllers
{
    public class AuthTokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm]string AppId)
        {
            string redirectUri = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/GetToken";
            string RequestPath = $"https://openauth.alipay.com/oauth2/appToAppAuth.htm?app_id={AppId}&redirect_uri=" + redirectUri;
            return Redirect(RequestPath);
        }
        [HttpGet("GetToken")]
        public IActionResult GetToken(string app_id, string app_auth_code)
        {
            return Json("AppId =" + app_id + ",app_auth_code="  + app_auth_code);
        }
    }
}