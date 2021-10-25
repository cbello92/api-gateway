using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Representation
{
    /*
     {
      "UpstreamPathTemplate": "/concepcion/api/{path}",
      "UpstreamHttpMethod": [ "GET" ],
      "DownstreamHostAndPorts": [
        {
          "Host": "jsonplaceholder.typicode.com",
          "Port": 443
        }
      ],
      "DownstreamPathTemplate": "/{path}",
      "AuthorizationOptions": {
        "AuthenticationProviderKey":  "Bearer"
      }
    }
     
     */
    public class RouteOcelot
    {
        public List<Route> Routes { get; set; }
    }
}
