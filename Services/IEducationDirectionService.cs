using Talim.DTOs;

namespace Talim.Services;

    public interface IEducationDirectionService
    {
        Task<Result<List<EducationDirection>>> GetAllByEducationTypeId(int id);
        Task<Result<EducationDirection>> GetById(int id);
        Task<Result<EducationDirection>> CreateEduDirection(int userId,NewEducationDirection educationDirection);
        Task<Result<EducationDirection>> UpdateById(int id,EducationDirectionUpdate educationDirection);
        Task<Result<EducationDirection>> DeleteById(int id);
    }