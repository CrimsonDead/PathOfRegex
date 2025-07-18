﻿namespace PathOfRegexDB.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IAsyncEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
