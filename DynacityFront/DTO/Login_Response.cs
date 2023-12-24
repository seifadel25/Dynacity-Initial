
namespace DynacityFront.DTO
{
    public class Login_Response
    {
        public Local_User_DTO User { get; set; }

        public List<string> Roles { get; set; }
        public string Token { get; set; }
    }
}
