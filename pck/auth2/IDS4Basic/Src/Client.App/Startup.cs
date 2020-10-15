using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Client.App.Data;
using System.IdentityModel.Tokens.Jwt;

namespace Client.App
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// TODO Database
			// note : I deleted the Data folder with the cs file for ApplicationDbContext
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			// TODO is this necessary both examples have it
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddControllersWithViews();

			// TODO necessary?
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
			.AddCookie("Cookies")
			.AddOpenIdConnect("oidc", options =>
			{
				options.SignInScheme = "Cookies";
				options.Authority = "https://localhost:5001";
				options.RequireHttpsMetadata = true;

				// TODO forgot this
				options.ClientId = "clientapp";
				// TODO generate secret i.e. guid below using powershell
				options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";

				// id_token
				options.ResponseType = "code";
				options.UsePkce = true;

				options.Scope.Clear();
				options.Scope.Add("openid");
				options.Scope.Add("profile");
				options.Scope.Add("offline_access");
				options.Scope.Add("client.api");

				// TODO what is this for
				//options.ClaimActions.MapJsonKey("website", "website");

				options.GetClaimsFromUserInfoEndpoint = true;
				options.SaveTokens = true;
			});

			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();

			// TODO check order or should this be above UseHttpsRedirection in Client.Api
			app.UseAuthentication();

			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseRouting();

			// order?? app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
