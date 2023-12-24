using DynacityFront.DTO;

namespace DynacityFront.Services.IServices
{
    public interface IDynacityService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(UserDTO id);
        Task<T> CreateAsync<T>(UserCreateDTO id);

        Task<T> UpdateAsync<T>(UserDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
