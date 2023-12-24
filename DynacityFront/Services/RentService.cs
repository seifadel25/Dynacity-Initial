using DynacityFront.DTO;
using DynacityFront.Services.IServices;
using Utility;

namespace DynacityFront.Services
{
    public class RentService : BaseService, IRentService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string dynacityURL;

        public RentService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            dynacityURL = configuration.GetValue<string>("ServiceUrls:DynacityAPI");
        }


        public Task<T> CreateAsync<T>(PropertyRentCreateDTO Rent, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = Rent,
                Token = token,
                Url = dynacityURL + "/api/Rent"

            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.DELETE,
                Token = token,
                Url = dynacityURL + "/api/Rent/" + id
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Rent",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Rent/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(RentUpdateDTO dto, string token)
        {

            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.PUT,
                Data = dto,
                Url = dynacityURL + "/api/Rent/" + dto.RentId,
                Token = token
            });
        }
    }
}
