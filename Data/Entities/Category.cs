
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("categories")]
    public class Category : BaseEntity
    {
		public Category(int id) : base(id)
		{
		}

		public string Title { get; set; }
		public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }
        public IEnumerable<MovieCategory> Movies { get; set; } = new List<MovieCategory>();
	}
}
