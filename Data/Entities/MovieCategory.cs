
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
	[Table("film_categories")]
	public class MovieCategory : BaseEntity
	{
		public int MovieId { get; set; }
		public int CategoryId { get; set; }
	}
}
