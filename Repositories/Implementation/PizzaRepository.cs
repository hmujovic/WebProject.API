using Microsoft.EntityFrameworkCore;
using WebProject.API.Data;
using WebProject.API.Domain.Models;

namespace WebProjectV1.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(DataContext dataContext) : base(dataContext) {}

        public void CreatePizza(Pizza pizza)
        {
            Create(pizza);
        }

        public void DeletePizza(Pizza pizza)
        {
            Delete(pizza);
        }

        public async Task<IEnumerable<Pizza>> GetAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            return (await FindByCondition(x => x.Id == id).SingleOrDefaultAsync())!;
        }

        public void UpdatePizza(Pizza pizza)
        {
            Update(pizza);
        }
    }
}