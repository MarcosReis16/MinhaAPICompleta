using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<int> Adicionar(TEntity entity);

        Task<TEntity> ObterPorId(Guid id);

        Task<List<TEntity>> ObterTodos();

        Task<int> Atualizar(TEntity entity);

        Task<int> Remover(Guid id);
        //Recebe uma expressão lambda para buscar alguma coisa.
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
