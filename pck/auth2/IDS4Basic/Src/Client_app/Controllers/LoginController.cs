using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client_app.Controllers
{
	public class LoginController : Controller
	{
		// This login screen should be in Identity Server, just redirect to Identity Server
		// taht will take it to show the login screen


		// GET: LoginController
		public ActionResult Login()
		{
			//return View();
			// instead of local view
			// Challenge is a Microsoft MVC function
			// Home controller, Index Action
			return Challenge(new AuthenticationProperties() { RedirectUri = "Home/Index" },
				Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme);
		}

		public ActionResult Logout()
		{
			//return View();
			return SignOut(new AuthenticationProperties() { RedirectUri = "Home/About"  },
				Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme,
				Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
		}

		//public ActionResult SignIn()
		//{
		//	// Authentication
		//}

		//// GET: LoginController/Details/5
		//public ActionResult Details(int id)
		//{
		//	return View();
		//}

		//// GET: LoginController/Create
		//public ActionResult Create()
		//{
		//	return View();
		//}

		//// POST: LoginController/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: LoginController/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//// POST: LoginController/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: LoginController/Delete/5
		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		//// POST: LoginController/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}
	}
}
