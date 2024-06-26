﻿using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Route("category")]
	[Controller]
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
			var viewModel = new CategoriesViewModel();

			viewModel.Categories = categories;
			return View(viewModel);
		}

		[HttpGet]
		[Route("add")]
		public async Task<IActionResult> AddCategory()
		{
			var categories = await _categoryService.GetAll();
			ViewBag.Categories = categories;

			return View();
		}

		[HttpPost]
		[Route("add")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddCategory([FromForm] CategoryModel model)
		{
			if (ModelState.IsValid)
			{
				await _categoryService.Add(model);
				return RedirectToAction("Index");
			}

			return BadRequest();
		}

		[HttpGet]
		[Route("delete/{id}")]
		public IActionResult DeleteCategory(int id)
		{
			_categoryService.DeleteById(id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("update/{id}")]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var categories = await _categoryService.GetAll();
			ViewBag.Categories = categories;

			var model = await _categoryService.GetById(id);
			return View(model);
		}

		[HttpPost]
		[Route("update/{id}")]
		public async Task<IActionResult> UpdateCategory(int id, [FromForm] CategoryModel model)
		{
			if (model is not null && ModelState.IsValid)
			{
				model.Id = id;
				await _categoryService.Update(model);
				return RedirectToAction("Index");
			}

			return BadRequest();
		}
	}
}
