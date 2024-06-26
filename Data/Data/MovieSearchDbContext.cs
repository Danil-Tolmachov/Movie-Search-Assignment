﻿using Data.Entities;
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
			modelBuilder.Entity<Movie>(entity =>
			{
				// Id
				entity.Property(e => e.Id)
					  .ValueGeneratedOnAdd();

				entity.HasKey(e => e.Id);

				// Column settings
				entity.Property(e => e.Title)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("name");

				entity.Property(e => e.Director)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("director");

				entity.Property(e => e.ReleaseDate)
					  .HasColumnName("release");

				// Navigation properties
				entity.HasMany(e => e.Categories)
					  .WithOne(e => e.Movie)
					  .HasForeignKey(e => e.MovieId);
			});

			modelBuilder.Entity<Category>(entity =>
			{
				// Id
				entity.Property(e => e.Id)
					  .ValueGeneratedOnAdd();

				entity.HasKey(e => e.Id);

				// Column settings
				entity.Property(e => e.Title)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("name");

				entity.Property(e => e.ParentCategoryId)
					  .HasColumnName("parent_category_id");

				// Navigation properties
				entity.HasOne(e => e.ParentCategory)
					  .WithMany()
					  .HasForeignKey(e => e.ParentCategoryId);

				entity.HasMany(e => e.ChildCategories)
					  .WithOne(e => e.ParentCategory)
					  .HasForeignKey(e => e.ParentCategoryId);

				entity.HasMany(e => e.Movies)
					  .WithOne(e => e.Category)
					  .HasForeignKey(e => e.CategoryId);
			});

			modelBuilder.Entity<MovieCategory>(entity =>
			{
				// Id
				entity.Property(e => e.Id)
					  .ValueGeneratedOnAdd();

				entity.HasKey(e => e.Id);

				// Composite keys
				entity.HasKey(e => new { e.MovieId, e.CategoryId });

				// Column settings
				entity.Property(e => e.MovieId)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("film_id");

				entity.Property(e => e.CategoryId)
					  .HasColumnType("varchar(200)")
					  .HasColumnName("category_id");

				// Navigation properties
				entity.HasOne(e => e.Movie)
					  .WithMany(m => m.Categories)
					  .HasForeignKey(e => e.MovieId)
					  .OnDelete(DeleteBehavior.Cascade);

				entity.HasOne(e => e.Category)
					  .WithMany(m => m.Movies)
					  .HasForeignKey(e => e.CategoryId)
					  .OnDelete(DeleteBehavior.Cascade);
			});

            // Seed Data
            modelBuilder.Entity<Movie>().HasData(SeedData.GetMovies());
            modelBuilder.Entity<Category>().HasData(SeedData.GetCategories());
			modelBuilder.Entity<MovieCategory>().HasData(SeedData.GetMovieCategory());

			base.OnModelCreating(modelBuilder);
        }
    }
}
