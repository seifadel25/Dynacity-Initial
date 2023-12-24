using DynacityFront.DTO;

namespace DynacityFront.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(Login_Request objToCreate);
        Task<T> RegisterAsync<T>(Register_Request objToCreate);
    }
}
