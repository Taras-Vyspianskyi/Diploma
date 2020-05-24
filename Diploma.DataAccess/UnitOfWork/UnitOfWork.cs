using System;
using System.Threading.Tasks;
using Diploma.DataAccess.Context;
using Diploma.DataAccess.Repositories;
using Diploma.Interfaces.Repositories;
using Diploma.Interfaces.UnitOfWork;

namespace Diploma.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext context;

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
            this.UserRepository = new UserRepository(context);
            this.CustomerRepository = new CustomerRepository(context);
            this.OrderRepository = new OrderRepository(context);
            this.WorkerRepository = new WorkerRepository(context);
            this.TimeToOrderRepository = new TimeToOrderRepository(context);
        }

        public IUserRepository UserRepository { get; set; }

        public ICustomerRepository CustomerRepository { get; set; }

        public IOrderRepository OrderRepository { get; set; }

        public IWorkerRepository WorkerRepository { get; set; }

        public ITimeToOrderRepository TimeToOrderRepository { get; set; }

        public void Dispose()
        {
            context?.Dispose();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
