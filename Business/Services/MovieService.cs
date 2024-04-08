using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
	public class MovieService : IMovieService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task AddCategory(int movieId, int categoryId)
		{
			await _unitOfWork.MovieCategoryRepository.AddAsync(movieId, categoryId);
			await _unitOfWork.SaveAsync();
		}

		public async Task RemoveCategory(int movieId, int categoryId)
		{
			await _unitOfWork.MovieCategoryRepository.DeleteAsync(movieId, categoryId);
			await _unitOfWork.SaveAsync();
		}

		public async Task ClearCategories(int movieId)
		{
			await _unitOfWork.MovieCategoryRepository.ClearMovieCategoriesAsync(movieId);
			await _unitOfWork.SaveAsync();
		}

		public async Task Add(MovieModel model)
		{
			var entity = _mapper.Map<Movie>(model);

			await _unitOfWork.MovieRepository.AddAsync(entity);
			await _unitOfWork.SaveAsync();
		}

		public async Task<int> Count()
		{
			return await _unitOfWork.MovieRepository.CountAsync();
		}

		public async Task Delete(MovieModel model)
		{
			var entity = _mapper.Map<Movie>(model);
			_unitOfWork.MovieRepository.Delete(entity);

			await _unitOfWork.SaveAsync();
		}

		public async Task DeleteById(int id)
		{
			await _unitOfWork.MovieRepository.DeleteByIdAsync(id);
			await _unitOfWork.SaveAsync();
		}

		public async Task<IEnumerable<MovieModel>> GetAll()
		{
			var entities = await _unitOfWork.MovieRepository.GetAllAsync();
			return _mapper.Map<IList<MovieModel>>(entities);
		}

		public async Task<IEnumerable<MovieModel>> GetAll(int pageNumber, int rowCount)
		{
			var entities = await _unitOfWork.MovieRepository.GetAllAsync(pageNumber, rowCount);
			return _mapper.Map<IList<MovieModel>>(entities);
		}

		public async Task<MovieModel> GetById(int id)
		{
			var entity = await _unitOfWork.MovieRepository.GetByIdAsync(id);
			return _mapper.Map<MovieModel>(entity);
		}

		public async Task Update(MovieModel model)
		{
			var entity = _mapper.Map<Movie>(model);

			await _unitOfWork.MovieRepository.UpdateAsync(entity);
			await _unitOfWork.SaveAsync();
		}
	}
}
