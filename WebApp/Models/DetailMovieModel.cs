using Business.Models;

namespace WebApp.Models
{
	public class DetailMovieModel
	{
		public MovieModel Movie { get; set; }
		public IEnumerable<CategoryModel> AvailableCategories { get; set; }

		public DetailMovieModel(MovieModel movie, IEnumerable<CategoryModel> availableCategories)
		{
			Movie = movie;
			AvailableCategories = availableCategories;
		}
	}
}
