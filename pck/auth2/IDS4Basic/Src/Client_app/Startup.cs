using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Client_app
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
			services.AddControllersWithViews();


			// configure client app, integrate with identity server
			// Client - Configure Identity Service
			// write a separate method
			ConfigureIdentityServer(services);
		}
		//created this method
		private void ConfigureIdentityServer(IServiceCollection services)
		{
			var builder = services.AddAuthentication(options => SetAuthenticationOptions(options));

			builder.AddCookie();
			builder.AddOpenIdConnect(options => SetOpenIdConnectOptions(options));
		}

		private void SetOpenIdConnectOptions(OpenIdConnectOptions options)
		{
			// IDS4.InMem > Properties
			options.Authority = "http://localhost:5001";
			// match the client's id name in the configuration
			options.ClientId = "client_app";
			options.RequireHttpsMetadata = false;
			options.Scope.Add("profile");
			options.Scope.Add("openid");
			options.ResponseType = "id_token";
		}


		// created this method
		private void SetAuthenticationOptions(AuthenticationOptions options)
		{
			// constant for this is "Cookies"
			options.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
			// constant for this is "OpenIdConnect"
			options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();
			// added
			app.UseCookiePolicy();

			app.UseRouting();

			app.UseAuthentication();
			// Identity Server configuration client side
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
