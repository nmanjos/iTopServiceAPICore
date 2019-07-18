using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTopClientService.Contract.V1.Response
{
    public class iTopCreateResponse
    {
        public Objects objects { get; set; }
    }

    public class Objects
    {
        public ObjectclassObjectkey objectclassobjectkey { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }

    public class ObjectclassObjectkey
    {
        public int code { get; set; }
        public string message { get; set; }
        public string _class { get; set; }
        public int key { get; set; }
        public Fields fields { get; set; }
    }

    public class Fields
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int org_id { get; set; }
    }
}
