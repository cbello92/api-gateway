using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Representation
{
    /*
     {
          "Host": "jsonplaceholder.typicode.com",
          "Port": 443
        }
     */
    public class HostAndPort
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
