using Data.Data;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class CategoryRepository : AbstractCrudRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieSearchDbContext context) : base(context)
        {

        }
	}
}
