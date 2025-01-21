using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class PasswordRepository : GenericRepository<Password>, IPasswordRepository{
    public PasswordRepository(ApplicationDbContext context) : base(context){}
}