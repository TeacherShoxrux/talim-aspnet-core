using Talim.Data;
using Talim.Data.Entity;

namespace Talim.Repositories;
public class ContentImageRepository : GenericRepository<ContentImage>, IContentImageRepository{
    public ContentImageRepository(ApplicationDbContext context) : base(context){}
}