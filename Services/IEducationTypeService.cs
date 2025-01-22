namespace Talim.DTOs;
public interface IEducationTypeService{
    Task<List<EducationType>> GetAll();
    Task<EducationType> GetById(int id);
    Task<EducationType> Add(NewEducationType newEducationType);
    Task<EducationType> Update( NewEducationType newEducationType);
    Task<EducationType> Delete(int id);
}