﻿using JobOpportunities.Domain;
using System.Linq.Expressions;

namespace JobOpportunities.Data.GenericRepository
{
    public interface IWriteRepository<T> //in, out, check covariant/contravariant     
    {
        void Add(T item);
        void Remove(T item);
        Task<bool> SaveAsync(CancellationToken cancellationToken);
        Task<bool> SaveAsync();
    }

    public interface IReadRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAllByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ItemExists(Guid id);
    }

    public interface IGenericRepository<T> : IReadRepository<T>, IWriteRepository<T>
      where T : IEntity
    {
    }
}