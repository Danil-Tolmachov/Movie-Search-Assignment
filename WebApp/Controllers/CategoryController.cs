using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Route("category")]
	[ApiController]
	public class CategoryController : Controller
	{
		public readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
		{
			var categories = await _categoryService.GetAll();
			var viewModel = new CategoryIndexModel();

			viewModel.Categories = categories;
			return View(model: viewModel);
		}

		[Route("update/{id}")]
		public IActionResult UpdateCategory(int id)
		{
			return View();
		} 
	}
}
