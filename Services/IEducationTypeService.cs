namespace Talim.DTOs;
public interface IEducationTypeService{
    Task<Result<List<EducationType>>> GetAll();
    Task<Result<EducationType>> GetById(int id);
    Task<Result<EducationType>> Add(NewEducationType newEducationType);
    Task<Result<EducationType>> Update( NewEducationType newEducationType);
    Task<Result<EducationType>> Delete(int id);
}