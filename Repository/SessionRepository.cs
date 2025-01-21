using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class SessionRepository : GenericRepository<Session>, ISessionRepository{

    public SessionRepository(ApplicationDbContext context) : base(context){}
}