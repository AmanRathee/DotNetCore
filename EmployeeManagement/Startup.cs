using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        //Get the configuration keys from appsettings.json
        public Startup(IConfiguration config)
        {
            _config = config;
        }




        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//services.AddMvc() will just add the main MVC library,not the related ones
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //*************************
            //app.UseDefaultFiles();//this will run the default.html/default.htm/index.html/index.htm
            //But if you want to make another html file as teh default html then use this overload:-
            //DefaultFilesOptions dfo = new DefaultFilesOptions();
            //dfo.DefaultFileNames.Clear();
            //dfo.DefaultFileNames.Add("Home.html");
            //app.UseDefaultFiles(dfo);
            //*************************




            app.UseStaticFiles();


            app.UseMvcWithDefaultRoute();




            //Middleware 1 :- app.Use will take an additional param "next" in the lambda expression 
            //It also needs to add "await next()" so that the next middleware is called up.
            app.Use(async (context,next) =>
            {
                logger.LogInformation("MW1 : Incoming");
                await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);

                //1.iisexpress when csproj has <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
                //and Visual Studio F5 is used.By default ,VS uses IISEXPRESS

                //2.dotnet when csproj has InProcess OR OutOfProcess 
                //and CLI is used :- dotnet run.Here Kestrel is the server used.

                //3.iisexpress when csproj has <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
                //and Visual Studio F5 is used.By default ,VS uses IISEXPRESS

                await next();
                logger.LogInformation("MW1 : outGoing");
            });

             app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2 : Incoming");
                await context.Response.WriteAsync("test");
                await next();
                logger.LogInformation("MW2 : outGoing");
            });

            //Middleware 3

            //Middleware 4 :- uses App.Run and acts like terminal middleware.
            //The following middlewares after this one wont get executed.
            app.Run(async (context) =>
            {
                //Read the appsetting config and write here
                await context.Response.WriteAsync(_config["MyCustomKey"]);
                logger.LogInformation("MW4 : Request Handled Completely.");

            });
        }
    }
}
