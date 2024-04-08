using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	[ApiController]
	[Route("api/movie")]
	public class MovieApiController : ControllerBase
	{
		private readonly IMovieService _movieService;
		private readonly ICategoryService _categoryService;

		public MovieApiController(IMovieService movieService, ICategoryService categoryService)
		{
			_movieService = movieService;
			_categoryService = categoryService;
		}

		/// <summary>
		/// Gets categories related to movie.
		/// </summary
		[HttpGet]
		[Route("{movieId}/category/")]
		public async Task<IEnumerable<CategoryModel>> GetMovieCategories(int movieId)
		{
			var movie = await _movieService.GetById(movieId);
			var availableCategories = await _categoryService.GetAll();

			// Get related categories
			var result = availableCategories.Where(c => c.Movies.Any(m => m.Id == movie.Id));

			return result;
		}

		/// <summary>
		/// Creates categories to movie relation with specified keys.
		/// </summary
		/// <param name="ids">Categories ids from form.</param>
		[HttpPost]
		[Route("{movieId}/category/")]
		public async Task<IActionResult> AddCategories(int movieId, [FromForm] IEnumerable<int> ids)
		{
			await _movieService.ClearCategories(movieId);

			foreach (var id in ids)
			{
				await _movieService.AddCategory(movieId, id);
			}

			return Ok();
		}

		/// <summary>
		/// Creates category to movie relation with specified key.
		/// </summary>
		[HttpPost]
		[Route("{movieId}/category/{categoryId}")]
		public async Task<IActionResult> AddCategory(int movieId, int categoryId)
		{
			await _movieService.AddCategory(movieId, categoryId);
		
			return Ok();
		}

		/// <summary>
		/// Removes category to movie relation with specified keys.
		/// </summary>
		[HttpDelete]
		[Route("{movieId}/category/{categoryId}")]
		public async Task<IActionResult> RemoveCategory(int movieId, int categoryId)
		{
			await _movieService.RemoveCategory(movieId, categoryId);

			return NoContent();
		}
	}
}
