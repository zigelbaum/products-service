using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Service.MyFirstService.Entities;

namespace Service.MyFirstService.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        // Task<T> GetCodeAsync(int id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}