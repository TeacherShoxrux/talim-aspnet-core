using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class EducationDirectionRepository : GenericRepository<EducationDirection>, IEducationDirectionRepository
{
    public EducationDirectionRepository(ApplicationDbContext context) : base(context)
    {
    }
}