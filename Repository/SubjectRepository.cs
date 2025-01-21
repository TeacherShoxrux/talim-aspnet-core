using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(ApplicationDbContext context) : base(context)
    {}
}