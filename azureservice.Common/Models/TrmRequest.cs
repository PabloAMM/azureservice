using Newtonsoft.Json;

namespace azureservice.Common.Models
{

    public class TrmRequest
    {
        public Connection connection { get; set; }
        public Exchange exchange { get; set; }
    }

    public class Connection
    {
        public string systemId { get; set; }
        public string token { get; set; }

    }

    public class Exchange
    {
        public string dateValidity { get; set; }

        [JsonProperty("base")]
        public string _base { get; set; }
        public string[] to { get; set; }
    }

}
