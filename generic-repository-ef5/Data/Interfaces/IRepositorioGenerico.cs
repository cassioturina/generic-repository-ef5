using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace generic_repository_ef5.Data.Interfaces
{
    public interface IRepositorioGenerico<TEntity> : IDisposable where TEntity : class
    {
        Task Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> ObterTodos(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> ObterPrimeiro(Expression<Func<TEntity, bool>> predicate);

        Task<int> Salvar();
    }
}
