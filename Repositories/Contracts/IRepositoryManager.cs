namespace WebProjectV1.Repositories
{
    public interface IRepositoryManager
    {
        IUnitOfWork UnitOfWork { get; }
        IPizzaRepository PizzaRepository { get; }
    }
}
