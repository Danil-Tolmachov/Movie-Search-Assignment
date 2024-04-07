using Business.Models;

namespace WebApp.Models
{
	public class MoviesViewModel
	{
		public IEnumerable<MovieModel> Movies { get; set; } = new List<MovieModel>();
	}
}
