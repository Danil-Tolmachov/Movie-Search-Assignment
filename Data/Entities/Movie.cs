
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("films")]
    public class Movie : BaseEntity
    {
		public Movie(int id) : base(id)
		{
		}

		public string Title { get; set; }
		public string Director { get; set; }
		public DateTime ReleaseDate { get; set; }

        public IEnumerable<MovieCategory> Categories { get; set; } = new List<MovieCategory>();
	}
}
