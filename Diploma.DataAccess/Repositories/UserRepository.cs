using Diploma.DataAccess.Context;
using Diploma.Interfaces.Entities;
using Diploma.Interfaces.Repositories;

namespace Diploma.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
