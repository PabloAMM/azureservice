using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace azureservice.Common.Response
{

    public class ServiceResponse
    {
        public Status status { get; set; }
        public Exchange exchange { get; set; }
    }

    public class Status
    {
        public int statusCode { get; set; }
        public string message { get; set; }
    }

    public class Exchange
    {
        public DateTime timeStamp { get; set; }

        [JsonProperty("base")]
        public string _base { get; set; }
        public DateTime validityDate { get; set; }
        public Rate[] rates { get; set; }
    }

    public class Rate
    {
        public string currency { get; set; }
        public string value { get; set; }
    }

}
