using JobOpportunities.Data;
using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobOpportunities.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly JobOpportunitiesContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(JobOpportunitiesContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.OrderBy(item => item.Id).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}