using generic_repository_ef5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace generic_repository_ef5.Data.Interfaces
{
    public interface IAutorRepositorio : IRepositorioGenerico<Autor>
    {
        Task<IEnumerable<Autor>> ObterComLivros();
    }
}
