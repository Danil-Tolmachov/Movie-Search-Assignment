using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
	public class MovieService : IMovieService
	{
		public Task Add(MovieModel model)
		{
			throw new NotImplementedException();
		}

		public Task<int> Count()
		{
			throw new NotImplementedException();
		}

		public void Delete(MovieModel model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteById(long id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MovieModel>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MovieModel>> GetAll(int pageNumber, int rowCount)
		{
			throw new NotImplementedException();
		}

		public Task<MovieModel> GetById(long id)
		{
			throw new NotImplementedException();
		}

		public void Update(MovieModel model)
		{
			throw new NotImplementedException();
		}
	}
}
