using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }

		protected BaseEntity(int id)
		{
			Id = id;
		}
	}
}
