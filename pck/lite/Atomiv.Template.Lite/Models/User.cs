//SIGN UP, SIGN IN form later on

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Models
{
	public class User
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }

		// have dropdown to select different roles
		public string Role { get; set; }
	}
}
