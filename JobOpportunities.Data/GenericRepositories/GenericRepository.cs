using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobOpportunities.Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly JobOpportunitiesContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(JobOpportunitiesContext dbContext)
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

        public async Task Remove(T item)
        {
            //_dbContext.Entry(item).State = EntityState.Deleted;
            _dbSet.Remove(item);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public async Task<bool> SaveAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAllByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<bool> ItemExists(Guid id)
        {
            return await _dbSet.FindAsync(id) is not null;
        }

        public bool Save()
        {
            try
            {
                return _dbContext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}