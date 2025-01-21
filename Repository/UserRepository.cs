using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }
}