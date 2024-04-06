
using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Movie, MovieModel>()
				.ForMember(mm => mm.Id, m => m.MapFrom(x => x.Id))
				.ForMember(mm => mm.Title, m => m.MapFrom(x => x.Title))
				.ForMember(mm => mm.Director, m => m.MapFrom(x => x.Director))
				.ForMember(mm => mm.ReleaseDate, m => m.MapFrom(x => x.ReleaseDate))
				.ForMember(mm => mm.Categories, m => m.MapFrom(x => x.Categories.Select(mc => mc.Category)));

			CreateMap<MovieModel, Movie>()
				.ForMember(m => m.Id, mm => mm.MapFrom(x => x.Id))
				.ForMember(m => m.Title, mm => mm.MapFrom(x => x.Title))
				.ForMember(m => m.Director, mm => mm.MapFrom(x => x.Director))
				.ForMember(m => m.ReleaseDate, mm => mm.MapFrom(x => x.ReleaseDate))
				.ForMember(m => m.Categories, mm => mm.Ignore());


			CreateMap<Category, CategoryModel>()
				.ForMember(cm => cm.Id, c => c.MapFrom(x => x.Id))
				.ForMember(cm => cm.Title, c => c.MapFrom(x => x.Title))
				.ForMember(cm => cm.ParentCategory, c => c.MapFrom(x => x.ParentCategory))
				.ForMember(cm => cm.ParentCategoryId, c => c.MapFrom(x => x.ParentCategoryId))
				.ForMember(cm => cm.Movies, c => c.MapFrom(x => x.Movies.Select(mc => mc.Movie)));

			CreateMap<CategoryModel, Category>()
				.ForMember(c => c.Id, cm => cm.MapFrom(x => x.Id))
				.ForMember(c => c.Title, cm => cm.MapFrom(x => x.Title))
				.ForMember(c => c.ParentCategory, cm => cm.Ignore())
				.ForMember(c => c.Movies, cm => cm.Ignore());
		}

		public static IMapper CreateMapper()
		{
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<AutoMapperProfile>();
			});

			config.AssertConfigurationIsValid();
			IMapper mapper = config.CreateMapper();

			return mapper;
		}
	}
}
