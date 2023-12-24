using DynacityFront.DTO;

namespace DynacityFront.Services.IServices
{
    public interface IRentService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(PropertyRentCreateDTO Rent, string token);

        Task<T> UpdateAsync<T>(RentUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
