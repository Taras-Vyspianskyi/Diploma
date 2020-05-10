using Diploma.DataAccess.Context;
using Diploma.Interfaces.Entities;
using Diploma.Interfaces.Repositories;

namespace Diploma.DataAccess.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
