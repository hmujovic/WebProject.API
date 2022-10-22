
using WebProject.API.Data;

namespace WebProjectV1.Repositories
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IPizzaRepository> _lazyPizzaRepository;
       
        public RepositoryManager(DataContext dbContext)
        {
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _lazyPizzaRepository = new Lazy<IPizzaRepository>(() => new PizzaRepository(dbContext));
        }

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

        public IPizzaRepository PizzaRepository => _lazyPizzaRepository.Value;
    }
}
