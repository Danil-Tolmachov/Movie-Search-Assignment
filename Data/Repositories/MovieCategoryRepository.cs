using Data.Data;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MovieCategoryRepository : IMovieCategoryRepository
    {
        protected readonly MovieSearchDbContext _context;
        protected readonly DbSet<MovieCategory> dbSet;

        public MovieCategoryRepository(MovieSearchDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<MovieCategory>();
        }

        public async Task AddAsync(int movieId, int categoryId)
        {
            MovieCategory entity = new MovieCategory()
            {
                MovieId = movieId,
                CategoryId = categoryId
            };

            await dbSet.AddAsync(entity);
        }

		public async Task DeleteAsync(int movieId, int categoryId)
		{
			MovieCategory entity = await dbSet.FindAsync(movieId, categoryId);

			dbSet.Remove(entity);
		}

		public async Task ClearMovieCategoriesAsync(int movieId)
		{
			IEnumerable<MovieCategory> entities = await dbSet.Where(e => e.MovieId == movieId).ToListAsync();

			dbSet.RemoveRange(entities);
		}
	}
}
