using System.Net;

namespace Dynacity.Models
{
    public class APIResponses
    {
        public APIResponses()
        {
            ErrorsMessages= new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; }
        public List<string> ErrorsMessages { get; set; }
        public object Result { get; set; }
    }
}
