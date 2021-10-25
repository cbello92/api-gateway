using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Representation
{
    /*
     {
        "AuthenticationProviderKey":  "Bearer"
      }
     */
    public class AuthorizationOptions
    {
        public string AuthenticationProviderKey { get; set; }
    }
}
