using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTopClientService.Contract.V1
{
    public class APIRoute
    {

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class iTopService
        {
            
            public const string CreateIncident = Base + "/iTopService";
            
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";
        }
    }
}
