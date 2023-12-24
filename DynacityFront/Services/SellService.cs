using DynacityFront.DTO;
using DynacityFront.Services.IServices;
using Utility;

namespace DynacityFront.Services
{
    public class SellService : BaseService, ISellService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string dynacityURL;

        public SellService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            dynacityURL = configuration.GetValue<string>("ServiceUrls:DynacityAPI");
        }


        public Task<T> CreateAsync<T>(PropertySellDTO Sell, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = Sell,
                Token = token,
                Url = dynacityURL + "/api/Sell"

            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.DELETE,
                Url = dynacityURL + "/api/Sell/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Sell",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int SellId, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Sell/" + SellId,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(SellUpdateDTO dto, string token)
        {

            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.PUT,
                Data = dto,
                Token = token,
                Url = dynacityURL + "/api/Sell/" + dto.SellId
            });
        }
    }
}
