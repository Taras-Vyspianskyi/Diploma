using Diploma.DataAccess.Context;
using Diploma.Interfaces.Entities;
using Diploma.Interfaces.Repositories;

namespace Diploma.DataAccess.Repositories
{
    public class TimeToOrderRepository : BaseRepository<TimeToOrder>, ITimeToOrderRepository
    {
        public TimeToOrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
