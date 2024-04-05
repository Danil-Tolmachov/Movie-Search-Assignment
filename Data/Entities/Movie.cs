
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("films")]
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
		public string Director { get; set; }
		public DateTime ReleaseDate { get; set; }
    }
}
