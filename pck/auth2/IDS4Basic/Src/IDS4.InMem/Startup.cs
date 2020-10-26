// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IDS4.InMem
{
	public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // asp.net identity support
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // asp.net identity support
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // TODO he did debug then got some value and that's the one he pasted into appsettings.json..
            // then he deleted this line
            //var secret = "8b83b118-1714-4a30-a338-b58dd43f610b".Sha256();

            services.AddControllersWithViews();

            // Identity Server 4 Configuration START
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            });
            //// asp.net identity support
            //.AddTestUsers(TestUsers.Users);
            builder.AddAspNetIdentity<ApplicationUser>();

            // in-memory, code config
            builder.AddInMemoryIdentityResources(Config.IdentityResources);
            builder.AddInMemoryApiScopes(Config.ApiScopes);
            builder.AddInMemoryClients(Config.Clients);
            // END


            // Configure External Identity Providers
            ConfigureExternalIdentityProviders(services);

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //        // register your IdentityServer with Google at https://console.developers.google.com
            //        // enable the Google+ API
            //        // set the redirect URI to https://localhost:5001/signin-google
            //        options.ClientId = "copy client ID from Google here";
            //        options.ClientSecret = "copy client secret from Google here";
            //    });
        }

		private void ConfigureExternalIdentityProviders(IServiceCollection services)
		{
            var authBuilder = services.AddAuthentication();

            //Google
            authBuilder.AddGoogle(GoogleDefaults.AuthenticationScheme, "Google Login", options => SetGoogleOptions(options));
		}

		private void SetGoogleOptions(GoogleOptions options)
		{
            options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //console.developers.gogole.com
            options.ClientId = "";
            options.ClientSecret = "";
		}

		public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            // Identity Server 4 configuration
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}