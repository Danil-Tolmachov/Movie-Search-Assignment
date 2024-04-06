
using AutoMapper;
using Business;
using Business.Interfaces;
using Business.Services;
using Data.Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
			services.AddControllers();
			services.AddRazorPages()
				    .AddRazorRuntimeCompilation();

			services.AddDbContext<MovieSearchDbContext>(options => 
				options.UseInMemoryDatabase(Guid.NewGuid().ToString())
				       .EnableSensitiveDataLogging(), 
						   ServiceLifetime.Singleton);

			services.AddSingleton<IMapper>(AutoMapperProfile.CreateMapper());

			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<IMovieService, MovieService>();
		}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MovieSearchDbContext context)
        {
			// Configure the HTTP request pipeline.
			if (!env.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			else
			{
				context.Database.EnsureCreated();

				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(e =>
				e.MapControllers());
		}
    }
}
