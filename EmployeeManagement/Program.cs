using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //Sets up the webhost that hosts our application with preconfigured defaults
            //Sets up teh web servers , loads the host and app config from various config sources
            //Configuring Logging
            //When     <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel> is found then 
            //UseIIS method is called by default.
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
