using JobOpportunities.Domain;
using System.Linq.Expressions;

namespace JobOpportunities.Repositories
{
    public interface IWriteRepository<T> //in, out, check covariant/contravariant     
    {
        void Add(T item);
        void Remove(T item);
        Task<bool> SaveAsync();
    }

    public interface IReadRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
      where T : IEntity
    {
    }
}