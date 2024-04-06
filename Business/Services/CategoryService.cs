using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Data;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task Add(CategoryModel model)
		{
			var entity = _mapper.Map<Category>(model);

			await _unitOfWork.CategoryRepository.AddAsync(entity);
			await _unitOfWork.SaveAsync();
		}

		public async Task<int> Count()
		{
			return await _unitOfWork.CategoryRepository.CountAsync();
		}

		public async Task Delete(CategoryModel model)
		{
			var entity = _mapper.Map<Category>(model);
			_unitOfWork.CategoryRepository.Delete(entity);

			await _unitOfWork.SaveAsync();
		}

		public async Task DeleteById(int id)
		{
			await _unitOfWork.CategoryRepository.DeleteByIdAsync(id);
			await _unitOfWork.SaveAsync();
		}

		public async Task<IEnumerable<CategoryModel>> GetAll()
		{
			var entities = await _unitOfWork.CategoryRepository.GetAllAsync();
			return _mapper.Map<IList<CategoryModel>>(entities);
		}

		public async Task<IEnumerable<CategoryModel>> GetAll(int pageNumber, int rowCount)
		{
			var entities = await _unitOfWork.CategoryRepository.GetAllAsync(pageNumber, rowCount);
			return _mapper.Map<IList<CategoryModel>>(entities);
		}

		public async Task<CategoryModel> GetById(int id)
		{
			var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
			return _mapper.Map<CategoryModel>(entity);
		}

		public async Task Update(CategoryModel model)
		{
			var entity = _mapper.Map<Category>(model);

			await _unitOfWork.CategoryRepository.UpdateAsync(entity);
			await _unitOfWork.SaveAsync();
		}
	}
}
