namespace azureservice.Common.Response
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Messsage { get; set; }
        public ServiceResponse Result { get; set; }
    }
}
