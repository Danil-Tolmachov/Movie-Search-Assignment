
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
	[Table("film_categories")]
	public class MovieCategory : BaseEntity
	{
		public int MovieId { get; set; }
		public Movie Movie { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
