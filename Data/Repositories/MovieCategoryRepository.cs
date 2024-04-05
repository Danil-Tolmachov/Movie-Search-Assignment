using Data.Data;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
	}
}
