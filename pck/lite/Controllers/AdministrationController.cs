using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Controllers
{
	public class AdministrationController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;

		// constructor to inject the Role Manager Service
		public AdministrationController(RoleManager<IdentityRole> roleManager)
		{
			this.roleManager = roleManager;
		}
	}
}
