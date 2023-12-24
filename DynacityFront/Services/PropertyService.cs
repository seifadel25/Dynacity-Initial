using DynacityFront.DTO;
using DynacityFront.Services.IServices;
using Utility;

namespace DynacityFront.Services
{
    public class PropertyService : BaseService, IPropertyService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string dynacityURL;
        public PropertyService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            dynacityURL = configuration.GetValue<string>("ServiceUrls:DynacityAPI");
        }

        //public Task<T> CreateAsync<T>(PropertyDTO dto, string token)
        //{
        //    return SendAsync<T>(new Models.APIRequest()
        //    {
        //        Apitype = SD.Apitype.POST,
        //        Data = dto,
        //        Url = dynacityURL + "/api/Property",
        //        Token = token
        //    });
        //}

        public Task<T> CreateAsync<T>(PropertyCreateDTO model, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.POST,
                Data = model,
                Url = dynacityURL + "/api/Property",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.DELETE,
                Url = dynacityURL + "/api/Property/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Property",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Property/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(PropertyDTO dto, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.PUT,
                Data = dto,
                Url = dynacityURL + "/api/Property/" + dto.PropertyId,
                Token = token
            });
        }
        public Task<T> SearchAsync<T>(string searchTerm, string token)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                Apitype = SD.Apitype.GET,
                Url = dynacityURL + "/api/Search/" + searchTerm,
                Token = token
            });
        }

        //public Task<T> UpdateAsync<T>(PropertyDTO dto)
        //{
        //    return SendAsync<T>(new Models.APIRequest()
        //    {
        //        Apitype = SD.Apitype.PUT,
        //        Data = dto,
        //        Url = dynacityURL + "/api/Property/" + dto.PropertyId
        //    });
        //}
    }
}
