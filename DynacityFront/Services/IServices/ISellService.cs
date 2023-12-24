using DynacityFront.DTO;

namespace DynacityFront.Services.IServices
{
    public interface ISellService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int SellId, string token);
        Task<T> CreateAsync<T>(PropertySellDTO Sell, string token);

        Task<T> UpdateAsync<T>(SellUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
