using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
	public static class SeedData
	{
		public static Movie[] GetMovies()
		{
			return new Movie[]
			{
				new Movie(1)
				{
					Title = "Movie1",
					Director = "Director1",
					ReleaseDate = DateTime.Now,
				},
				new Movie(2)
				{
					Title = "Movie2",
					Director = "Director2",
					ReleaseDate = DateTime.Now,
				},
				new Movie(3)
				{
					Title = "Movie3",
					Director = "Director1",
					ReleaseDate = DateTime.Now,
				},
				new Movie(4)
				{
					Title = "Movie4",
					Director = "Director3",
					ReleaseDate = DateTime.Now,
				},
				new Movie(5)
				{
					Title = "Movie5",
					Director = "Director3",
					ReleaseDate = DateTime.Now,
				},
			};
		}

		public static Category[] GetCategories()
		{
			return new Category[]
			{
				new Category(1)
				{
					Title = "Category1",
					ParentCategoryId = null,
					ParentCategory = null,
					Movies = new List<MovieCategory>(),
				},
				new Category(2)
				{
					Title = "Category2",
					ParentCategoryId = null,
					ParentCategory = null,
					Movies = new List<MovieCategory>(),
				},
				new Category(3)
				{
					Title = "Category3",
					ParentCategoryId = 1,
					ParentCategory = null,
					Movies = new List<MovieCategory>(),
				},
				new Category(4)
				{
					Title = "Category4",
					ParentCategoryId = 2,
					ParentCategory = null,
					Movies = new List<MovieCategory>(),
				},
				new Category(5)
				{
					Title = "Category5",
					ParentCategoryId = 2,
					ParentCategory = null,
					Movies = new List<MovieCategory>(),
				},
				new Category(6)
				{
					Title = "Category6",
					ParentCategoryId = 5,
					ParentCategory = null,
					Movies = new List<MovieCategory>(),
				},
			};
		}

		public static MovieCategory[] GetMovieCategory()
		{
			return new MovieCategory[]
			{
				new MovieCategory()
				{
					MovieId = 1,
					CategoryId = 1,
				},
				new MovieCategory()
				{
					MovieId = 2,
					CategoryId = 5,
				},
				new MovieCategory()
				{
					MovieId = 3,
					CategoryId = 1,
				},
				new MovieCategory()
				{
					MovieId = 4,
					CategoryId = 5,
				},
				new MovieCategory()
				{
					MovieId = 2,
					CategoryId = 1,
				},
				new MovieCategory()
				{
					MovieId = 6,
					CategoryId = 3,
				},
				new MovieCategory()
				{
					MovieId = 5,
					CategoryId = 2,
				},
			};
		}
	}
}
