namespace Talim.DTOs;
public interface IEducationTypeService{
    Task<Result<List<EducationType>>> GetAll();
    Task<Result<EducationType>> GetById(int id);
    Task<Result<EducationType>> Add(int userId,NewEducationType newEducationType);
    Task<Result<EducationType>> Update(int userId, NewEducationType newEducationType);
    Task<Result<EducationType>> Delete(int userId,int id);
}