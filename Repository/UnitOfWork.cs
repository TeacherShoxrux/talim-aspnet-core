using Talim.Data;

namespace Talim.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable {
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context){
        _context = context;
    }

    public IUserRepository UserRepository => _UserRepository ??= new UserRepository(_context);
    public ISessionRepository SessionRepository => _SessionRepository ??= new SessionRepository(_context);
    public IPasswordRepository PasswordRepository => _PasswordRepository ??= new PasswordRepository(_context);
    public IEducationTypeRepository EducationTypeRepository => _EducationTypeRepository ??= new EducationTypeRepository(_context);
    public IEducationDirectionRepository EducationDirectionRepository => _EducationDirectionRepository ??= new EducationDirectionRepository(_context);
    public ISubjectRepository SubjectRepository => _SubjectRepository ??= new SubjectRepository(_context);
    public IThemeRepository ThemeRepository => _ThemeRepository ??= new ThemeRepository(_context);
    public IContentRepository ContentRepository => _ContentRepository ??= new ContentRepository(_context);
    public IContentImageRepository ContentImageRepository => _ContentImageRepository ??= new ContentImageRepository(_context);

    public void Dispose() {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    UserRepository? _UserRepository ;
    SessionRepository? _SessionRepository ;
    PasswordRepository? _PasswordRepository ;
    EducationTypeRepository? _EducationTypeRepository;
    EducationDirectionRepository? _EducationDirectionRepository ;
    SubjectRepository? _SubjectRepository ;
    ThemeRepository? _ThemeRepository ;
    ContentRepository? _ContentRepository ;
    ContentImageRepository? _ContentImageRepository ;
}
