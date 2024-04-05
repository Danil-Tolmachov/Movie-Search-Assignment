using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class MovieSearchDbContext : DbContext
    {
        public MovieSearchDbContext(DbContextOptions<MovieSearchDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MoviesCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
            });

            // TODO: Configure other entities

            base.OnModelCreating(modelBuilder);
        }
    }
}
