using System.Data.Entity;
using System.Linq.Expressions;
using WebProject.API.Data;

namespace WebProjectV1.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        protected BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<T> FindAll()
        {
            return _dataContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dataContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            _dataContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }
    }
}