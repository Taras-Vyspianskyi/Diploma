using Diploma.DataAccess.Context;
using Diploma.Interfaces.Entities;
using Diploma.Interfaces.Repositories;

namespace Diploma.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
