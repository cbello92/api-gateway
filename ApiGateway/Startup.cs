using ApiGateway.Handlers;
using ApiGateway.Representation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiGateway
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
            services.AddOcelot()
                .AddDelegatingHandler<RemoveEncodingDelegatingHandler>(true);

            var ocelotConfig = new RouteOcelot();
            ocelotConfig.Routes = new List<Route>()
            {
                new Route()
                {
                    AuthorizationOptions = new AuthorizationOptions()
                    {
                        AuthenticationProviderKey = "Bearer"
                    }
                }
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonConvert.SerializeObject(ocelotConfig, Formatting.Indented);
            File.WriteAllText(@"C:\Users\camil\Desktop\ApiGateway\ApiGateway\path.json", json);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot().Wait();
        }
    }
}
