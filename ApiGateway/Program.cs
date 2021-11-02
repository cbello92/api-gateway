using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StreamReader r = new StreamReader("base.json");
            string jsonString = r.ReadToEnd();

            dynamic jsonRoutes = JsonConvert.DeserializeObject(jsonString);
            OcelotConfig ocelotConfig = new OcelotConfig();

            //dynamic routesConcepcion = ocelotConfig.BuildRoutesConcepcion(jsonRoutes);
            //dynamic routesChillan = ocelotConfig.BuildRoutesChillan(jsonRoutes);

            //List<dynamic> routesConcat = new List<dynamic>();

            var ocelotObject = new
            {
                Routes = ocelotConfig.ConsolidateRoutes(jsonRoutes),
                GlobalConfiguration = new
                {
                    BaseUrl = "https://localhost:5000"
                } 
            };

            //foreach (var item in ocelotConfig.ConsolidateRoutes(jsonRoutes))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("FROM PROGRAM");

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonConvert.SerializeObject(ocelotObject, Formatting.Indented);
            File.WriteAllText(@"C:\Users\camil\Desktop\ApiGateway\ApiGateway\ocelot.json", json);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hosting, config) => {
                    config.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
