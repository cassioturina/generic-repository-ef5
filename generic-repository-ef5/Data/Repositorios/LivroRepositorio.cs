using generic_repository_ef5.Data.Interfaces;
using generic_repository_ef5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace generic_repository_ef5.Data.Repositorios
{
    public class LivroRepositorio : RepositorioGenerico<Livro>, ILivroRepositorio
    {
        private readonly AppDataContext appDataContext;

        public LivroRepositorio(AppDataContext appDataContext) : base(appDataContext)
        {
            this.appDataContext = appDataContext;
        }
        public async Task<IEnumerable<Livro>> ObterComAutores()
        {
            return await appDataContext.Livros.Include(x => x.Autores).ToListAsync();
        }

    }
}
