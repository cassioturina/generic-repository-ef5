using generic_repository_ef5.Data.Interfaces;
using generic_repository_ef5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generic_repository_ef5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepositorio autorRepositorio;

        public AutorController(IAutorRepositorio autorRepositorio)
        {
            this.autorRepositorio = autorRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadatrarAutorDto autordto)
        {

            var autor = new Autor
            {
                Nome = autordto.Nome
            };

            foreach (var livro in autordto.Livros)
            {
                autor.Livros.Add(new Livro
                {
                    Titulo = livro.Titulo
                });
            }


            try
            {
                autorRepositorio.Adicionar(autor);
                await autorRepositorio.Salvar();
                return Ok(new
                {
                    sucesso = true,
                    mensagem = "Autor Cadastrado Com Sucesso"
                });

            }
            catch (System.Exception ex)
            {

                return BadRequest(new
                {
                    sucesso = false,
                    mensagem = $"Erro ao Cadastrar o autor - {ex.Message}"
                });
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Autualizar(int id, AtualizarAutorDto autordto)
        {
            var autor = await autorRepositorio.ObterPrimeiro(x => x.Id == id);

            if (autor == null)
            {
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "Autor não encontrado"

                });
            }

            autor.Nome = autordto.Nome;

            try
            {
                autorRepositorio.Atualizar(autor);
                await autorRepositorio.Salvar();
                return Ok(new
                {
                    sucesso = true,
                    mensagem = "Autor Atualizado Com Sucesso"
                });

            }
            catch (System.Exception ex)
            {

                return BadRequest(new
                {
                    sucesso = false,
                    mensagem = $"Erro ao Cadastrar o autor - {ex.Message}"
                });
            }

        }


        [HttpGet]
        public async Task<IActionResult> Autores()
        {
            var autores = await autorRepositorio.ObterTodos();

            if (!autores.Any())
            {
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "Autores não encontrado"

                });
            }

            return Ok(new
            {
                Sucesso = true,
                Data = autores.Select(x => new
                {
                    x.Nome,
                    x.Id
                })
            });
        }

        [HttpGet("livros")]
        public async Task<IActionResult> AutoresComLivros()
        {
            var autores = await autorRepositorio.ObterComLivros();

            if (autores == null)
            {
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "Autores não encontrado"

                });
            }

            return Ok(new
            {
                Sucesso = true,
                Data = autores.Select(x => new
                {
                    x.Nome,
                    x.Id,
                    Livros = x.Livros.Select(l => new
                    {
                        l.Id,
                        l.Titulo
                    }).ToList()
                })
            });
        }
    }

    public class CadatrarAutorDto
    {
        public string Nome { get; set; }
        public IList<CadastrarLivroDto> Livros { get; set; }
    }

    public class CadastrarLivroDto
    {
        public string Titulo { get; set; }
    }

    public class AtualizarAutorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
