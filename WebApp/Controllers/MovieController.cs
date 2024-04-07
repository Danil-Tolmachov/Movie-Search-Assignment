using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	[ApiController]
	[Route("movie")]
	public class MovieController : Controller
	{
		public readonly IMovieService _movieService;

		public MovieController(IMovieService movieService)
		{
			_movieService = movieService;
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
	}
}
