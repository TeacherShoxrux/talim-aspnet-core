using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class ContentRepository : GenericRepository<Content>, IContentRepository
{
    public ContentRepository(ApplicationDbContext context) : base(context) { }
}