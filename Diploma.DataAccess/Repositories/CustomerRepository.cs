using Diploma.DataAccess.Context;
using Diploma.Interfaces.Entities;
using Diploma.Interfaces.Repositories;

namespace Diploma.DataAccess.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
