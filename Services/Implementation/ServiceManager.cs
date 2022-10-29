using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProjectV1.Repositories;
using WebProjectV1.Services.Abstraction;

namespace WebProjectV1.Services.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPizzaService> _lazyPizzaService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyPizzaService = new Lazy<IPizzaService>(() => new PizzaService(repositoryManager)); ;
        }

        public IPizzaService PizzaService => _lazyPizzaService.Value;
    }
}