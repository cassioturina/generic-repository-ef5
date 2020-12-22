using generic_repository_ef5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace generic_repository_ef5.Data.Interfaces
{
    public interface ILivroRepositorio : IRepositorioGenerico<Livro>
    {
        Task<IEnumerable<Livro>> ObterComAutores();
    }
}
