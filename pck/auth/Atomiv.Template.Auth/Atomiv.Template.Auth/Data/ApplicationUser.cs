using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Auth.Data
{
	public class ApplicationUser : IdentityUser
	{
		public string City { get; set; }
		/* is this just for MVC
		 * [PersonalData]
		 * [Column(TypeName="nvarchar(100)")]
		 * public string FirstName { get; set; }
		 */

		/*
		 * [Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
		*/
	}
}

// Models > AppUser.cs
/*
 * namespace Atomiv.Template.Auth.Models
{
	public class AppUser : IdentityUser<int>
	{
		public string City { get; set; }
		public string Surname { get; set; }
	}
}
*/