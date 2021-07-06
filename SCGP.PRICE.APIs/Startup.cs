using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SCGP.PRICE.Core.BL.Operation;
using SCGP.PRICE.Core.BL.Product;
using SCGP.PRICE.Core.BL.Sale;
using SCGP.PRICE.Core.BL.Formula;
using SCGP.PRICE.Core.Context;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SCGP.PRICE.Core.BL.Customer;
using System.Reflection;
using SCGP.PRICE.Core.BL.Bags;
using SCGP.PRICE.Core.BL.ProductionCost;
using SCGP.PRICE.Core.BL.ShippingArea;
using SCGP.PRICE.Core.BL.Vender;
using SCGP.PRICE.Core.BL.Secure;
using SCGP.PRICE.Core.BL.BusinessUnit;

namespace SCGP.PRICE.APIs
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
            services.AddControllers();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);
            Utils.AppSetting = appSettingsSection.Get<AppSetting>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                          bulider => bulider
                                    .AllowAnyHeader()
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod().Build());
            });

            services.AddDbContext<SCGPDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDbConnection>(db => new SqlConnection(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<SCGPRawSqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMemoryCache();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SCGP PRICE API Documents",
                    Version = "v1"
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "SCGP.PRICE.APIs.xml");
                c.IncludeXmlComments(xmlPath);

            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            services.AddTransient<IProduct, Product>();
            services.AddTransient<IPreSale, PreSale>();
            services.AddTransient<IFormula, Formula>();
            services.AddTransient<ISale, Sale>();
            services.AddTransient<ICustomer, Customer>();
            services.AddTransient<IBag, Bag>();
            services.AddTransient<IProductionCost, ProductionCost>();
            services.AddTransient<IShippingArea, ShippingArea>();
            services.AddTransient<IVender, Vender>();
            services.AddTransient<IUserAccountBL, UserAccountBL>();
            services.AddTransient<IUserRole, UserRole>();
            services.AddTransient<IBusiness, Business>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SCGP System");
                c.RoutePrefix = "help";
                c.DisplayRequestDuration();
            });
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowAllOrigins");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
