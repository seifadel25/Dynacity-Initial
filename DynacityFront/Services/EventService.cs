using DynacityFront.DTO;
using DynacityFront.Services.IServices;
using Utility;

namespace DynacityFront.Services
{
    public class EventService : BaseService, IEventService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string dynacityURL;

        public EventService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            dynacityURL = configuration.GetValue<string>("ServiceUrls:DynacityAPI");
        }


        public Task<T> CreateAsync<T>(EventCreateDTO dto)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = dto,
                Url = dynacityURL + "/api/Event"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.DELETE,
                Url = dynacityURL + "/api/Event/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Event",
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Event/" + id,
            });
        }

        public Task<T> UpdateAsync<T>(EventUpdateDTO dto)
        {

            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.PUT,
                Data = dto,
                Url = dynacityURL + "/api/Event/" + dto.EventId,
            });
        }
    }
}
