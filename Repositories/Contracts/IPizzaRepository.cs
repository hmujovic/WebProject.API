using WebProject.API.Domain.Models;

namespace WebProjectV1.Repositories
{
    public interface IPizzaRepository : IBaseRepository<Pizza>
    {
        Task<IEnumerable<Pizza>> GetAllAsync();
        Task<Pizza> GetByIdAsync(int id);
        void CreatePizza(Pizza pizza);
        void UpdatePizza(Pizza pizza);
        void DeletePizza(Pizza pizza);
    }
}