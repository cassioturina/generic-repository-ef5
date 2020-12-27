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
        protected readonly AppDataContext appDataContext;
        protected readonly DbSet<TEntity> DbSet;

        public RepositorioGenerico(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        public async Task Adicionar(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }


        public async Task<TEntity> ObterPrimeiro(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ObterTodos(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();

        }

        public async Task<int> Salvar()
        {
            return await appDataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            appDataContext?.Dispose();
        }
    }
}
