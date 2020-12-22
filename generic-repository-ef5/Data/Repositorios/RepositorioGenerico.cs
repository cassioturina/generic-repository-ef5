using generic_repository_ef5.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace generic_repository_ef5.Data.Repositorios
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class 
    {
        private readonly AppDataContext appDataContext;

        public RepositorioGenerico(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        public void Adicionar(TEntity entity)
        {
            appDataContext.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            appDataContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<TEntity> ObterPrimeiro(Expression<Func<TEntity, bool>> predicate)
        {
            return await appDataContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await appDataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ObterTodos(Expression<Func<TEntity, bool>> predicate)
        {
            return await appDataContext.Set<TEntity>().Where(predicate).ToListAsync();

        }

        public async Task<int> Salvar()
        {
            return await appDataContext.SaveChangesAsync();
        }
    }
}
