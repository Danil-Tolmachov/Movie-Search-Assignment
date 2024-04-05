using Data.Interfaces;
using Data.Interfaces.Repositories;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieSearchDbContext _context;
        private IMovieRepository movieRepository;
        private ICategoryRepository categoryRepository;
        private IMovieCategoryRepository movieCategoryRepository;

        public IMovieRepository MovieRepository
		{
            get
            {
                if (this.movieRepository == null)
                {
                    this.movieRepository = new MovieRepository(this._context);
                }
                return movieRepository;
            }
        }

        public ICategoryRepository CategoryRepository
		{
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(this._context);
                }
                return categoryRepository;
            }
        }

		public IMovieCategoryRepository MovieCategoryRepository
		{
			get
			{
				if (this.movieCategoryRepository == null)
				{
					this.movieCategoryRepository = new MovieCategoryRepository(this._context);
				}
				return movieCategoryRepository;
			}
		}

		public UnitOfWork(MovieSearchDbContext context)
        {
            this._context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
