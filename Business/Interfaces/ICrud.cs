
namespace Business.Interfaces
{
	public interface ICrud<TModel>
	{
		Task<int> Count();

		Task Add(TModel model);

		Task<IEnumerable<TModel>> GetAll();

		Task<IEnumerable<TModel>> GetAll(int pageNumber, int rowCount);

		Task<TModel> GetById(int id);

		Task DeleteById(int id);

		Task Delete(TModel model);

		Task Update(TModel model);
	}
}
