using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace DotNetCoreOData
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
            services.AddDbContext<DotNETCodeFirstMigrationContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DotNETCodeFirstMigrationContext"));
            });

            services.AddTransient<IProductService, ProductService>();

            //normal routing
            //services.AddControllers().AddOData(options =>
            //    options.Select().Filter().OrderBy().Count().Expand().SetMaxTop(3)
            //);

            //for count and odata edm
            services.AddControllers().AddOData(options =>
                options.Select().Filter().OrderBy().Count().Expand().SetMaxTop(999999)
                .AddRouteComponents("odata", GetEdmModel()) //this is the custom routing and also enable counting
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Product>("ProductOdata");
            return modelBuilder.GetEdmModel();
        }
    }
}
