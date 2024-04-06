using Business.Models;

namespace Business.Interfaces
{
	public interface IMovieService : ICrud<MovieModel>
	{
		Task AddCategory(int movieId, int categoryId);
		Task RemoveCategory(int movieId, int categoryId);
	}
}
