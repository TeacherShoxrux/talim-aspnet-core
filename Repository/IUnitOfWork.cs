namespace Talim.Repositories;
public interface IUnitOfWork : IDisposable{
    IUserRepository UserRepository { get; }
    ISessionRepository SessionRepository { get; }
    IPasswordRepository PasswordRepository { get; }
    IEducationTypeRepository EducationTypeRepository { get; }
    IEducationDirectionRepository EducationDirectionRepository { get; }
    ISubjectRepository SubjectRepository { get; }
    IThemeRepository ThemeRepository { get; }
    IContentRepository ContentRepository { get; }
    IContentImageRepository ContentImageRepository { get; }
    int Save();
}