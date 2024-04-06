﻿using Business.Interfaces;
using Business.Models;
using Data.Data;

namespace WebApp.Models
{
	public class CategoryIndexModel
	{
		public IEnumerable<CategoryModel> Categories { get; set; } = null!;

	}
}
