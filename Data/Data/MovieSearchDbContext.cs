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

			modelBuilder.Entity<Movie>(entity =>
			{
				entity.Property(e => e.Title)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("name");

				entity.Property(e => e.Director)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("director");

				entity.Property(e => e.ReleaseDate)
					  .HasColumnName("release");
			});

			modelBuilder.Entity<Category>(entity =>
			{
				entity.Property(e => e.Title)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("name");

				entity.Property(e => e.ParentCategoryId)
					  .HasColumnName("parent_category_id");
			});

			modelBuilder.Entity<MovieCategory>(entity =>
			{
				entity.HasKey(e => new { e.MovieId, e.CategoryId });

                entity.Property(e => e.MovieId)
				      .HasColumnType("varchar(200)")
					  .HasColumnName("film_id");

				entity.Property(e => e.CategoryId)
                      .HasColumnType("varchar(200)")
					  .HasColumnName("category_id");
			});

			base.OnModelCreating(modelBuilder);
        }
    }
}
