using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTopClientService.Contract.V1.Requests
{
    public class iTopCreateRequest
    {
        public string operation { get; set; }
        public string comment { get; set; }
        public string _class { get; set; }
        public string output_fields { get; set; }
        public Fields fields { get; set; }
    }

    public class Fields
    {
        public string org_id { get; set; }
        public Caller_Id caller_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Caller_Id
    {
        public string name { get; set; }
        public string first_name { get; set; }
    }
}

