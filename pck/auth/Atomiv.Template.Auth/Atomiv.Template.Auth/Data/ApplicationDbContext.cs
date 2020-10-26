using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atomiv.Template.Auth.Data
{
	// public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	// IdentityDbContext contains all the user tables
	public class ApplicationDbContext : IdentityDbContext
	{
		// to add properties like City, Gender
		// your application DbContext class must inherit from IdentityDbContext
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// end up creating EmployeeDB, same level as as aspnet-
		/* // to add properties like City, Gender
		 * // public DbSet<Employee> Employees { get; set; }
		 * 
		 * protected override void OnModelCraeting(ModelBuilder modelBuilder)
		 * {
		 *		base.OnModelCreating(modelBuilder);
		 *		modelBuilder.Seed();
		 *	}
		 */
	}
}


//Models > IdentityAppContext.cs
/*
 * 
namespace Atomiv.Template.Auth.Models
{
	public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
	{
		public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
		{

		}
	}
}
 * */