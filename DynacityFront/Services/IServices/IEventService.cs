using DynacityFront.DTO;

namespace DynacityFront.Services.IServices
{
    public interface IEventService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(EventCreateDTO Event);

        Task<T> UpdateAsync<T>(EventUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
