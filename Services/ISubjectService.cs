using Talim.DTOs;

namespace Talim.Services;
public interface ISubjectService{
    ValueTask<Result<List<Subject>>> GetSubjectsByEducationDirectionIdAsync(int id);
    ValueTask<Result<Subject>> GetSubjectByIdAsync(int id);
    ValueTask<Result<List<Subject>>> GetTopSubjectsAsync(int max=10);
    ValueTask<Result<Subject>> CreateSubjectAsync(int userId,NewSubject newSubject);
    ValueTask<Result<Subject>> UpdateSubjectAsync(int id, NewSubject newSubject);
    ValueTask<Result<Subject>> DeleteSubjectAsync(int id);}