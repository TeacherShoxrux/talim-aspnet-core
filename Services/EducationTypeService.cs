using Microsoft.EntityFrameworkCore;
using Talim.DTOs;
using Talim.Repositories;

namespace Talim.Services;
public class EducationTypeService : IEducationTypeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EducationTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork=unitOfWork;
    }
    public async Task<Result<EducationType>> Add(int userId, NewEducationType newEducationType)
    {
        try
        {
            var eduType = await _unitOfWork.
                    EducationTypeRepository.
                    AddAsync(new()
                    {
                        Name=newEducationType.Name,
                        Description =  newEducationType.Description,
                        UserId=userId
                        
                    });
            _unitOfWork.Save();
            return new(true)
            {
                Data=new(){
                    Name=eduType.Name,
                    Description=eduType.Description,
                    Image=eduType.Description,
                    CreatedAt=eduType.CreatedAt,
                    UpdatedAt=eduType.UpdatedAt,
                }
            };
        }
        catch (System.Exception)
        {
            return new("Talim turini yaratishda xatolik uz berdi. Iltimos, qoʻllab-quvvatlash xizmatiga murojaat qiling(An error occurred while creating the training type. Please contact support.)");
        }
 
    }

    public Task<Result<EducationType>> Delete(int userId,int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<EducationType>>> GetAll()
    {
        try
        {
            var eduTypes = await _unitOfWork.EducationTypeRepository.GetAllAsync().ToListAsync();
            return new(true)
            {
                Data = eduTypes.Select(eduType => new EducationType
                {
                    Name = eduType.Name,
                    Description = eduType.Description,
                    Image = eduType.Image,
                    CreatedAt = eduType.CreatedAt,
                    UpdatedAt = eduType.UpdatedAt,
                }).ToList()
            };
        }
        catch (System.Exception e)
        {
            
           return new($"Ta'lim turini olishda xalik yuz berdi (There was a problem with obtaining the type of education.{e.Message})");
 
        }
    }

    public Task<Result<EducationType>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<EducationType>> Update(int userId,NewEducationType newEducationType)
    {
        throw new NotImplementedException();
    }
}