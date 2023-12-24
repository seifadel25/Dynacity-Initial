using DynacityFront.DTO;
using DynacityFront.Services.IServices;
using Utility;

namespace DynacityFront.Services
{
    public class DynacityService : BaseService, IDynacityService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string dynacityURL;
        public DynacityService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            dynacityURL = configuration.GetValue<string>("ServiceUrls:DynacityAPI");
        }

        public Task<T> CreateAsync<T>(UserDTO dto)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = dto,
                Url = dynacityURL + "/api/User"
            });
        }

        public Task<T> CreateAsync<T>(UserCreateDTO model)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = model,
                Url = dynacityURL + "/api/User"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.DELETE,
                Url = dynacityURL + "/api/User/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/User"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/User/" + id
            });
        }

        public Task<T> UpdateAsync<T>(UserDTO dto)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.PUT,
                Data = dto,
                Url = dynacityURL + "/api/User/" + dto.UserID
            });
        }
    }
}
