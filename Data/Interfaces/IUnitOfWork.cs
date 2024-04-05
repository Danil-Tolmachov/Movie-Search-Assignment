using System.Threading.Tasks;
using Data.Interfaces.Repositories;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IMovieCategoryRepository MovieCategoryRepository { get; }

        Task SaveAsync();
    }
}
