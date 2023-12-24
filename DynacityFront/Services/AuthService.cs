using DynacityFront.DTO;
using DynacityFront.Services.IServices;
using Utility;

namespace DynacityFront.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string dynacityURL;

        public AuthService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {

            _httpClientFactory = httpClient;
            dynacityURL = configuration.GetValue<string>("ServiceUrls:DynacityAPI");

        }

        public Task<T> LoginAsync<T>(Login_Request obj)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = obj,
                Url = dynacityURL + "/api/UsersAuth/login"
            });
        }


        public Task<T> RegisterAsync<T>(Register_Request obj)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = obj,
                Url = dynacityURL + "/api/UsersAuth/Register"
            });
        }
    }
}
