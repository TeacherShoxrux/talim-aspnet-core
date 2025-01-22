using Talim.DTOs;

namespace Talim.Services;
public interface ISubjectService{
    ValueTask<List<Subject>> GetSubjectsByEducationDirectionIdAsync(int id);
    ValueTask<Subject> GetSubjectByIdAsync(int id);
    ValueTask<Subject> CreateSubjectAsync(NewSubject newSubject);
    ValueTask<Subject> UpdateSubjectAsync(int id, NewSubject newSubject);
    ValueTask DeleteSubjectAsync(int id);
}