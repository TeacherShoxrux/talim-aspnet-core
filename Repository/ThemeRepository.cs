using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class  ThemeRepository : GenericRepository<Theme>, IThemeRepository
{
    public ThemeRepository(ApplicationDbContext context) : base(context)
    {}
}