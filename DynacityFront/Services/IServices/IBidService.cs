﻿using DynacityFront.DTO;

namespace DynacityFront.Services.IServices
{
    public interface IBidService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(PropertyBidCreateDTO id, string token);

        Task<T> UpdateAsync<T>(BidsUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
