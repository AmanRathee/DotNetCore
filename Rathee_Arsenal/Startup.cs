using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rathee_Arsenal.Data;
using Rathee_Arsenal.Data.Mock;
using Rathee_Arsenal.Data.Model;
using Rathee_Arsenal.Data.Repository;

namespace Rathee_Arsenal
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IWeaponRepository, WeaponRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();


            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp=>ShoppingCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();

            app.UseSession();
            //app.UseMVC(routes=>
            //{
            //     routes.MapRoute("default","{controller=Home}/{action=index}/{id?}");
            //}
            //Below is same as above
            app.UseMvcWithDefaultRoute();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DbContext>();

                DBInitializer.Seed(app);
            }

        }
    }
}
