using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiGateway
{
    
    public class OcelotConfig
    {
        public static T Clone<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public dynamic BuildRoutesConcepcion(dynamic baseJSON)
        {

            dynamic routesConcepcion = Clone(baseJSON);

            foreach (var item in routesConcepcion)
            {
                if(item["UpstreamPathTemplate"].ToString().Contains("base"))
                {
                    item["UpstreamPathTemplate"] = item["UpstreamPathTemplate"].ToString().Replace("base", "concepcion");
                    item["DownstreamHostAndPorts"][0]["Host"] = "localhost";
                    item["DownstreamHostAndPorts"][0]["Port"] = 5002;
                }
            }

            return routesConcepcion;
        }


        public dynamic BuildRoutesChillan(dynamic baseJSON)
        {

            dynamic routesChillan = Clone(baseJSON);

            foreach (var item in routesChillan)
            {
                if (item["UpstreamPathTemplate"].ToString().Contains("base"))
                {
                    item["UpstreamPathTemplate"] = item["UpstreamPathTemplate"].ToString().Replace("base", "chillan");
                    item["DownstreamHostAndPorts"][0]["Host"] = "chillanapi.cl";
                    item["DownstreamHostAndPorts"][0]["Port"] = 80;
                }
            }

            return routesChillan;
        }


        public List<dynamic> ConsolidateRoutes(dynamic baseJSON)
        {
            List<dynamic> routesConcat = new List<dynamic>();
            dynamic routesConcepcion = BuildRoutesConcepcion(baseJSON);
            dynamic routesChillan = BuildRoutesChillan(baseJSON);


            foreach (var item in routesConcepcion)
            {
                if(routesConcat.FindAll(x => x["UpstreamPathTemplate"] == item["UpstreamPathTemplate"]).Count == 0)
                {
                    routesConcat.Add(item);
                }
            }

            foreach (var item in routesChillan)
            {
                if (routesConcat.FindAll(x => x["UpstreamPathTemplate"] == item["UpstreamPathTemplate"]).Count == 0)
                {
                    routesConcat.Add(item);
                }
            }

            return routesConcat;
        }

    }
}
