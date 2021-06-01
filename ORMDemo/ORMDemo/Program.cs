using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ORMDemo.Model;
using ORMDemo.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configurationRoot = configuration.Build();
            SqlHelper.ConStr = configurationRoot["ConStr"];
            SqlHelper sqlHelper = new SqlHelper();
            Products products = sqlHelper.Find<Products>(1);
            Products products2 = sqlHelper.Find<Products>(2);

            //sqlHelper.Insert<Products>(products);
            //sqlHelper.Insert<Products>(products2);

            products2.ProductName = "≤‚ ‘“ªœ¬";
            products2.Price = 90;
            sqlHelper.Update<Products>(products2);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
