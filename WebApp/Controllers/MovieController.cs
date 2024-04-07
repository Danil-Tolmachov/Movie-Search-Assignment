using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Controller]
	[Route("movie")]
	public class MovieController : Controller
	{
		public readonly IMovieService _movieService;
		public readonly ICategoryService _categoryService;

		public MovieController(IMovieService movieService, ICategoryService categoryService)
		{
			_movieService = movieService;
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
		{
			var movies = await _movieService.GetAll();
			var viewModel = new MoviesViewModel();

			viewModel.Movies = movies;
			return View(viewModel);
		}

		[HttpGet]
		[Route("add")]
		public IActionResult AddMovie()
		{
			return View();
		}

		[HttpPost]
		[Route("add")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddMovie([FromForm] MovieModel model)
		{
			if (ModelState.IsValid)
			{
				await _movieService.Add(model);
				return RedirectToAction("Index", "Movie");
			}

			return BadRequest();
		}

		[HttpGet]
		[Route("delete/{id}")]
		public IActionResult DeleteMovie(int id)
		{
			_movieService.DeleteById(id);
			return RedirectToAction("Index", "Movie");
		}

		[HttpGet]
		[Route("update/{id}")]
		public async Task<IActionResult> UpdateMovie(int id)
		{
			var model = await _movieService.GetById(id);
			return View(model);
		}

		[HttpPost]
		[Route("update/{id}")]
		public async Task<IActionResult> UpdateMovie(int id, [FromForm] MovieModel model)
		{
			if (model is not null && ModelState.IsValid)
			{
				model.Id = id;
				await _movieService.Update(model);
				return RedirectToAction("Index", "Movie");
			}

			return BadRequest();
		}

		[Route("detail/{id}")]
		public async Task<IActionResult> DetailMovie(int id)
		{
			var movie = await _movieService.GetById(id);
			var availableCategories = await _categoryService.GetAll();

			// Exclude already related categories
			availableCategories = availableCategories.Where(c => !c.Movies.Any(m => m.Id == movie.Id));

			var viewModel = new DetailMovieModel(movie, availableCategories);
			return View("DetailMovie", viewModel);
		}
	}
}
