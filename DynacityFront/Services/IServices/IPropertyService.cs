using DynacityFront.DTO;

namespace DynacityFront.Services.IServices
{
    public interface IPropertyService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(PropertyCreateDTO id, string token);

        Task<T> UpdateAsync<T>(PropertyDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
        Task<T> SearchAsync<T>(string search, string token);
    }
}
