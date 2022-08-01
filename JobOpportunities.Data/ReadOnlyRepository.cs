using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobOpportunities.Data
{
    public class ReadOnlyRepository<T> : IReadRepository<T> where T : class, IEntity
    {
        private readonly JobOpportunitiesContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public ReadOnlyRepository(JobOpportunitiesContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().OrderBy(item => item.Id).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().SingleAsync(item => item.Id == id);
        }

        public async Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }
    }
}
