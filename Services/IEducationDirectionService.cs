using Talim.DTOs;

namespace Talim.Services;

    public interface IEducationDirection
    {
        Task<List<EducationDirection>> GetAllByEducationTypeId(int id);
        Task<EducationDirection> GetById(int id);
        Task<EducationDirection> CreateEducationDirectionByEducationType(int id,EducationDirectionCreate educationDirection);
        Task<EducationDirection> UpdateById(int id,EducationDirectionUpdate educationDirection);
        Task<EducationDirection> DeleteById(int id);
    }