using generic_repository_ef5.Data.Interfaces;
using generic_repository_ef5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace generic_repository_ef5.Data.Repositorios
{
    public class AutorRepositorio : RepositorioGenerico<Autor>, IAutorRepositorio
    {

        public AutorRepositorio(AppDataContext appDataContext) : base(appDataContext)
        { }

        public async Task<IEnumerable<Autor>> ObterComLivros()
        {
            return await appDataContext.Autores.Include(x => x.Livros).ToListAsync();
        }

    }
}
