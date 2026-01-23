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
using Atomiv.Template.Lite.Entities;
using Commander.Data;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Options;
using Atomiv.Template.Lite.Services.Interfaces;
using Atomiv.Template.Lite.Services;
using Microsoft.OpenApi.Models;
using Atomiv.Template.Lite.Repositories.Interfaces;
using Atomiv.Template.Lite.Repositories;
using Mapster;
using MapsterMapper;
using Atomiv.Template.Lite.Mapping;

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
            services.AddDbContext<DatabaseContext>(opt =>
                // microsoft docs
                // JECA
                // opt.UseInMemoryDatabase("ECommerceList"));
                // change name? - GetConnectionString("ECommerceAPIContext");
                // jc
                // opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                opt.UseSqlServer(connectionString));
            services.AddControllers();
            // services.AddScoped<ICommanderRepo,  MockCommanderRepo>();
            // Configure Swagger after it's installed
            // add Swagger to Dependency Injection container
            // (options -- completely optional
            services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new Info { Title = "My API", Version = :v1" });
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Atomiv Template Lite",
                        Description = "Demo showing orders",
                        Version = "v1"
                    });
                
                // generate xml file - optional. to view comments in swagger .. schemas
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Configure Mapster
            MappingConfig.Configure();
            var config = new TypeAdapterConfig();
            config.Scan(typeof(Startup).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // configure method is where we setup our request pipeline, order in which middle is added is important
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        // rename to AppDbContext db
        DatabaseContext db)
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

            // here in the Configure method (see above) add Swagger
            app.UseSwagger();
            // Swagger UI to be available
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                // to go into Swagger when RUN and empty url, get swagger documentataion
                // localhost:44315/
                // localhost:44315/index.html
                // remove this if you prefer localhost:44315/swagger...
                //options.RoutePrefix = "";
                //options.RoutePrefix = string.Empty;

            });
        }
    }
}
