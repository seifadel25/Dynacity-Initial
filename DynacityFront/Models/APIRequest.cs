using static Utility.SD;

namespace DynacityFront.Models
{
    public class APIRequest
    {
        public Apitype Apitype { get; set; } = Apitype.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
