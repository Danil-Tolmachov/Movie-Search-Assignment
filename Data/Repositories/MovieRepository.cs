using Data.Data;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MovieRepository : AbstractCrudRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieSearchDbContext context) : base(context)
        {

        }

		public override async Task<IEnumerable<Movie>> GetAllAsync()
		{
			return await this.dbSet.Include(e => e.Categories)
							       .ThenInclude(c => c.Category)
								   .ToListAsync();
		}

		public override async Task<IEnumerable<Movie>> GetAllAsync(int pageNumber, int rowCount)
		{
			if (pageNumber < 1)
				throw new ArgumentException("Page number should be greater than or equal to 1.", nameof(pageNumber));

			if (rowCount < 1)
				throw new ArgumentException("Row count should be greater than or equal to 1.", nameof(rowCount));


			int pagesLimit = (int)Math.Ceiling((await dbSet.CountAsync()) / (double)rowCount);

			if (pageNumber > pagesLimit)
			{
				return Enumerable.Empty<Movie>();
			}

			int entitiesToSkip = (pageNumber - 1) * rowCount;

			return await dbSet.Skip(entitiesToSkip)
							  .Take(rowCount)
							  .Include(e => e.Categories)
							  .ThenInclude(c => c.Category)
							  .ToListAsync();
		}

		public override async Task<Movie> GetByIdAsync(int id)
		{
			try
			{
				return await this.dbSet.Include(e => e.Categories)
									   .ThenInclude(c => c.Category)
									   .FirstAsync(e => e.Id == id);
			}
			catch (InvalidOperationException ex)
			{
				throw new ArgumentException("Provided id does not exist", ex);
			}
		}
	}
}
