using Microsoft.EntityFrameworkCore;
using Talim.DTOs;
using Talim.Repositories;

namespace Talim.Services;
 public class EducationDirectionService : IEducationDirectionService
{
    private readonly IUnitOfWork _unitOfWork;

    public EducationDirectionService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<Result<EducationDirection>> CreateEduDirection(int userId,NewEducationDirection educationDirection)
    {
        try
        {
            var edutype = await _unitOfWork.EducationTypeRepository.GetByIdAsync(educationDirection.EducationTypeId);
            if (edutype == null)
            {
                return new("Talim turi topilmadi yoki mavjud emas boshqa ta'lim turini tanlang yoki tekshirib qaytadan harakat qiling (The training type was not found or does not exist. Please select another training type or check and try again).");
            }
            var  eduDirection = await _unitOfWork.EducationDirectionRepository.AddAsync(
                new()
                {
                Name=educationDirection.Name,
                Description=educationDirection.Description,
                UserId = userId,
                EducationTypeId=educationDirection.EducationTypeId
                });
            _unitOfWork.Save();
            return new(true){
                Data=new(){
                    Name=eduDirection.Name,
                    Description=eduDirection.Description,
                    CreatedAt=eduDirection.CreatedAt,
                    UpdatedAt=eduDirection.UpdatedAt,
                    Image=eduDirection.Image,
                    Id=eduDirection.Id
                }
            };
            
        }
        catch (System.Exception e)
        {
            
           return new($"Ta'lim yo'nalishi yaratishda xatolik yuz berdi (An error occurred while creating the course.):{e.Message}");

        }
        
    }

    public Task<Result<EducationDirection>> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<EducationDirection>>> GetAllByEducationTypeId(int id)
    {
        try
        {
            var eduTypes = await _unitOfWork.EducationDirectionRepository.
                    GetAllAsync().
                    Where(e=>e.EducationTypeId==id).
                    ToListAsync();
            return new(true)
            {
                Data = eduTypes.Select(e=> new EducationDirection(){
                    Name=e.Name,
                    Description=e.Description,
                    Id = e.Id,
                    CreatedAt=e.CreatedAt,
                    UpdatedAt=e.UpdatedAt,
                    Image=e.Image
                    }).ToList()
            };
        }
        catch (System.Exception e)
        {
            return new($"Ta'lim yo'nalishlarini olishda xatolik yuz berdi(There was an error retrieving Education Type.):{e.Message}");
        }
    }

    public Task<Result<EducationDirection>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<EducationDirection>> UpdateById(int id, EducationDirectionUpdate educationDirection)
    {
        throw new NotImplementedException();
    }
}