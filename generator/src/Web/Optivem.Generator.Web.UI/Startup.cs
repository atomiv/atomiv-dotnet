using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Reflection;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Infrastructure.NewtonsoftJson;
using Optivem.Atomiv.Infrastructure.System.Reflection;
using Optivem.Generator.Core.Application.Customers;
using Optivem.Generator.Web.RestClient;
using Optivem.Generator.Web.RestClient.Http;
using Optivem.Generator.Web.RestClient.Interface;
using Optivem.Generator.Web.UI.Services;
using Optivem.Generator.Web.UI.Services.Interfaces;

namespace Optivem.Generator.Web.UI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiClientOptions>(Configuration.GetSection("ApiClient"));

            services.AddScoped<IClient, ApiClient>();
            services.AddScoped<IJsonSerializer, JsonSerializer>();
            services.AddScoped<IPropertyMapper, PropertyMapper>();

            services.AddScoped<IControllerClientFactory, JsonControllerClientFactory>();
            services.AddScoped<ICustomerHttpService, CustomerHttpService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerPageService, CustomerPageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
