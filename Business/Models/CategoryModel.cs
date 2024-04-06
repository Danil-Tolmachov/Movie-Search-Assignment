using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
	public class CategoryModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public int ParentCategoryId { get; set; }

		public CategoryModel? ParentCategory { get; set; }
		public IEnumerable<MovieModel> Movies { get; set; } = new List<MovieModel>();
	}
}
