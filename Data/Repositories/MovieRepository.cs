using Data.Data;
using Data.Entities;
using Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Repositories;
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
    }
}
