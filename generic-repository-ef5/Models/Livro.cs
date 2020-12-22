using System.Collections.Generic;

namespace generic_repository_ef5.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public IList<Autor> Autores { get; set; } = new List<Autor>();
    }
}
