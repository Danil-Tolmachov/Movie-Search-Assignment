using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(int pageNumber, int rowCount);

		Task<TEntity> GetByIdAsync(int id);

		Task<int> CountAsync();

        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
		Task DeleteByIdAsync(int id);

		Task UpdateAsync(TEntity entity);
    }
}
