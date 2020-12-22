using generic_repository_ef5.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace generic_repository_ef5.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<Autor> Autores  { get; set; }
        public DbSet<Livro> Livros { get; set; }

    }
}
