using Data.Data;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : AbstractCrudRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieSearchDbContext context) : base(context)
        {

        }

		public override async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await this.dbSet.Include(e => e.Movies)
								   .Include(e => e.ParentCategory)
								   .ToListAsync();
		}

		public override async Task<IEnumerable<Category>> GetAllAsync(int pageNumber, int rowCount)
		{
			if (pageNumber < 1)
				throw new ArgumentException("Page number should be greater than or equal to 1.", nameof(pageNumber));

			if (rowCount < 1)
				throw new ArgumentException("Row count should be greater than or equal to 1.", nameof(rowCount));


			int pagesLimit = (int)Math.Ceiling((await dbSet.CountAsync()) / (double)rowCount);

			if (pageNumber > pagesLimit)
			{
				return Enumerable.Empty<Category>();
			}

			int entitiesToSkip = (pageNumber - 1) * rowCount;

			return await dbSet.Skip(entitiesToSkip)
						      .Take(rowCount)
						      .Include(e => e.Movies)
							  .Include(e => e.ParentCategory)
							  .ToListAsync();
		}

		public override async Task<Category> GetByIdAsync(int id)
		{
			try
			{
				return await this.dbSet.Include(e => e.Movies)
									   .Include(e => e.ParentCategory)
									   .FirstAsync(e => e.Id == id);
			}
			catch (InvalidOperationException ex)
			{
				throw new ArgumentException("Provided id does not exist", ex);
			}
		}
	}
}
