using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
class EducationTypeRepository : GenericRepository<EducationType>, IEducationTypeRepository
{
    public EducationTypeRepository(ApplicationDbContext context) : base(context)
    {}
}