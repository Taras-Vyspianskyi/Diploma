using Diploma.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Diploma.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        IUserRepository UserRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        IOrderRepository OrderRepository { get; }

        IWorkerRepository WorkerRepository { get; }
    }
}
