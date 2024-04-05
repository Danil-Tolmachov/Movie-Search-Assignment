using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
	public class MovieModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Director { get; set; } = string.Empty;
		public DateTime ReleaseDate { get; set; }

		public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
	}
}
