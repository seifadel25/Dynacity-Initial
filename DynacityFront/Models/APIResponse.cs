using System.Net;

namespace DynacityFront.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorsMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; }
        public List<string> ErrorsMessages { get; set; }
        public object Result { get; set; }
    }
}
