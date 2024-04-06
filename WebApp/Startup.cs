using Microsoft.AspNetCore.Mvc.RazorPages;

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
			services.AddRazorPages()
				    .AddRazorRuntimeCompilation();
		}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			// Configure the HTTP request pipeline.
			if (!env.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(e =>
				e.MapRazorPages());
		}
    }
}
