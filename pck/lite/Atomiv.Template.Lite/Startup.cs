using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Lite.Models;
using Commander.Data;

namespace Atomiv.Template.Lite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // here we add services
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // don't need 2 lines below for Commander
            // services.AddDbContext<Data.LibraryContext>
            services.AddDbContext<ECommerceContext>(opt =>
                // microsoft docs
                // JECA
                // opt.UseInMemoryDatabase("ECommerceList"));
                // change name? - GetConnectionString("ECommerceAPIContext");
                // jc
                // opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                opt.UseSqlServer(connectionString));
            services.AddControllers();
            // if something changes down teh line, just change MockCommanderRepo
            // british guy
            // services.AddScoped<ICommanderRepo,  MockCommanderRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // configure method is where we setup our request pipeline, order in which middle is added is important
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        // rename to AppDbContext db
        ECommerceContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // jc
            db.Database.EnsureCreated();
            // Applying EF Core migrations programmatically
            // In the preceding section you created and applied the migrations using .NET Core CLI. You can also apply the created migrations via code
            // db.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
