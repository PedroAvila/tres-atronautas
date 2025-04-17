using System;

namespace astronautas.port;

public interface IMongoRepository<T>
    where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(string id);

    Task<T> CreateAsync(T entity);

    Task UpdateAsync(string id, T entity);

    Task DeleteAsync(string id);
}
