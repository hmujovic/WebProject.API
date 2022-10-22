

using WebProject.API.Data;

namespace WebProjectV1.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        public UnitOfWork(DataContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
