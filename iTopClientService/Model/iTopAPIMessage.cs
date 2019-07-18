using iTopClientService.Contract.V1.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTopClientService.Model
{
    public class iTopAPIMessage
    {
        public string EndPoint { get; set; }
        public iTopCreateRequest Create { get; set; }
        public string Credentials { get; set; }
    }



    internal class Credentials
    {
        [JsonProperty("agent")]
        public Agent Agent { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    internal class Agent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
