using DynacityFront.DTO;
using DynacityFront.Services.IServices;
using Utility;

namespace DynacityFront.Services
{
    public class BidService : BaseService, IBidService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string dynacityURL;
        public BidService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            dynacityURL = configuration.GetValue<string>("ServiceUrls:DynacityAPI");
        }

        public Task<T> CreateAsync<T>(PropertyBidCreateDTO dto, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = dto,
                Token = token,
                Url = dynacityURL + "/api/Bids"
            });
        }


        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.DELETE,
                Token = token,
                Url = dynacityURL + "/api/Bids/" + id
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Token = token,
                Url = dynacityURL + "/api/Bids"
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Token = token,
                Url = dynacityURL + "/api/Bids/" + id
            });
        }



        public Task<T> UpdateAsync<T>(BidsUpdateDTO dto, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.PUT,
                Data = dto,
                Token = token,
                Url = dynacityURL + "/api/Bid/" + dto.BidId
            });
        }
    }
}
