using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Controllers
{
	// or ApplicationUser
	public class UsersController
	{
		// in [HTTPPost]
		// model.Role = "Customer";
		// ...
		// var result = await _userManager.CreateAsync(user, model.Password)
		// await _userManager.AddRoleAsync(user, model.Role)
		// return Ok(result)
	}
}
