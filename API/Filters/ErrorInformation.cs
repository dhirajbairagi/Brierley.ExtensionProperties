using System.Net;

namespace API.Filters
{
    public class ErrorInformation
    {
        public HttpStatusCode HttpStatus { get; set; }
        public string DeveloperMessage { get; set; }
        public string UserMessage { get; set; }
        public int ErrorCode { get; set; }
        public string MoreInfo { get; set; }
    }
}
