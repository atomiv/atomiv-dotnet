// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IS4Demo.Data;
using IS4Demo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.JSInterop.Infrastructure;
using System.Reflection;

namespace IS4Demo
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
            services.AddControllersWithViews();

            //... Store conenction string as a var
            //... var connectionString = Configuration.GetConnectionString("DefaultConnection")
            //... Store assembly for migrations
            //... var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            // Replace DbContext database from SqLite in template to SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                //... options.UseSqlServer(connectionString));
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                //options.Events.RaiseErrorEvents = true;
                //options.Events.RaiseInformationEvents = true;
                //options.Events.RaiseFailureEvents = true;
                //options.Events.RaiseSuccessEvents = true;

                //// see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                //options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                //... use our SQL db for storing configuration data
                /*... instead of 3 lines above
                .AddConfigurationStore(configDb =>
				{
                    configDb.ConfigureDbContext = db => db.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
				})
                //...use our SQL Database for storing operational data
                .AddOperationalStore(operationalDb => {
                    operationDb.ConfigureDbContexr = db => db.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
                })*/
                .AddAspNetIdentity<ApplicationUser>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    
                    // register your IdentityServer with Google at https://console.developers.google.com
                    // enable the Google+ API
                    // set the redirect URI to https://localhost:5001/signin-google
                    options.ClientId = "656662697276-duaugu330rkl2ep94k7s7p23vddpukm8.apps.googleusercontent.com";
                    options.ClientSecret = "vFeZzfkiX-_bE3njm8CrZ1g";
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            //... InitializeDatabase(app);

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            /*
             * private void InitializeDatabase(IApplicationBuilder app) {
             *  // using a services scope
                 * using (var service Scope =
                 *      app.ApplicationServices.GetService<IserviceScopefactory>()
                 *      .CreateScope())
                 * {
                 *      // create PersistedGrant Database (we're using a single db here)
                 *      var persistedGrantDbContext = serviceScope.ServiceProvider
                 *          .GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                 *      persistedGrantDbContext.Database.Migrate();
                 *      
                 *      var configDbContext = serviceScope.ServiceProvider
                 *          .GetRequiredService<ConfigurationDbContext>();
                 *      configDbContext.Database.Migrate();
                 *      
                 *      if(!configDbContext.Clients.Any()) {
                 *          foreach(var client in Config.GetClients()) {
                 *              configDbContext.Clients.Add(client.ToEntity());
                 *          }
                 *          configDbContext.SaveChanges();
                 *      }
                 *      
                 *      if(!configDbContext.IdentityResources.Any()) {
                 *          foreach(var res in Config.GetIdentityResources()) {
                 *              configDbContext.IdentityResources.Add(res.ToEntity());
                 *          }
                 *          configDbContext.SaveChanges();
                 *      }
                 *      
                 *      if(!configDbContext.ApiResources.Any()) {
                 *          foreach(var api in Config.GetApis()) {
                 *              configDbContext.ApiResources.Add(api.ToEntity());
                 *          }
                 *          configDbContext.SaveChanges();
                 *      }
                 *      
                 *  }
             *  }
             * */
        }
    }
}


// NOTE: 
//... appsettings.json -> edit "DefaultConnection" for the SQL Server
//... open up SQL Server
//... In SQL create database etc..
//... delete Migrations folder from Data folder

//... for migrations, check if it's installed
//... ISD4Demo> dotnet ef migrations add initial_identity_migration -c ApplicationDbContext -o data/Migrations/AspNetIdentity/ApplicationDb
//... ISD4Demo> dotnet ef migrations add initial_is4_server_config_migration -c ConfigurationDbContext -o data/Migrations/AspNetIdentity/ConfigurationDb
//... he created a database, gave permission
//... ISD4Demo> dotnet ef migrations add initial_is4_persisted_grant_migration -c PersistedGrantDbContext -o data/Migrations/AspNetIdentity/PersistedGrantDb
//... ISD4Demo> dotnet ef database update --context ApplicationDbContext
//... go into SQL Server and you will see all the tabels like AspNetUsers
//... generate tables that identity server 4 requires
//... ISD4Demo> dotnet ef database update --context ConfigurationDbContext
//... 
//... ISD4Demo> dotnet ef database update --context PersistedGrantDbContext

//... AspNetUsers (SQL Server) , ClientClaims, identityResources (IDS4), PersistedGrants (PersistedGrants)

// seed our database with initial data, note SeedData.cs
// ISD4Demo> dotnet run /seed
// users were created with claims, added to AspNetUsers table in SQL Server...