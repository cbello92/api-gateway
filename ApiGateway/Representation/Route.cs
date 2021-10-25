using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiGateway.Representation
{
    public class Route
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? UpstreamPathTemplate { get; set; }
        public string UpstreamHttpMethod { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public List<HostAndPort> DownstreamHostAndPorts { get; set; }
        public AuthorizationOptions AuthorizationOptions { get; set; }
    }
}
