using Data.Entities;
using System.Threading.Tasks;

namespace Data.Interfaces.Repositories
{
    public interface IMovieCategoryRepository
    {
		Task AddAsync(int movieId, int categoryId);
		Task DeleteAsync(int movieId, int categoryId);

	}
}
