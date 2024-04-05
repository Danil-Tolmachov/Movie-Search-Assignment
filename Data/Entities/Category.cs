
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("categories")]
    public class Category : BaseEntity
    {
        public string Title { get; set; }
		public int? ParentCategoryId { get; set; }
    }
}
