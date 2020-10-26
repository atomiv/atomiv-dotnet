using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Client.App.Controllers
{
	public class AccountController : Controller
	{
        //TODO IMPORTANT?
		public IActionResult Login()
		{
			//return Challenge("oidc");

            return Challenge(new AuthenticationProperties() { RedirectUri = "Home/Index" }, "oidc");
        }

        //[HttpGet]
        //public async Task Login()
        //{
        //    await HttpContext.ChallengeAsync("oidc", new AuthenticationProperties() { RedirectUri = "/my-callback-page" });
        //}

        public IActionResult Logout()
		{
            return SignOut("Cookies", "oidc");
        }

        /*
		 * // TODO : study more details about what happens here when signing out
        [HttpPost]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
		------------------------------
		        // GET: Login
        public ActionResult Login()
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = "Home/Index" },
                Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme);
        } 
        
       public ActionResult Logout()
        {
            return SignOut(new AuthenticationProperties() { RedirectUri = "Home/About" },
                Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme,
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

        }
		 * */

    }
}
