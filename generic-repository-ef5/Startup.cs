using generic_repository_ef5.Data;
using generic_repository_ef5.Data.Interfaces;
using generic_repository_ef5.Data.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace generic_repository_ef5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<AppDataContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddTransient<AppDataContext>();
            services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            services.AddTransient<IAutorRepositorio, AutorRepositorio>();
            services.AddTransient<ILivroRepositorio, LivroRepositorio>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
