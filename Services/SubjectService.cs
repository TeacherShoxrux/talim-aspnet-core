using Microsoft.EntityFrameworkCore;
using Talim.DTOs;
using Talim.Repositories;

namespace Talim.Services;

public class SubjectService : ISubjectService
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<Subject>> CreateSubjectAsync(int userId,NewSubject newSubject)
    {
        try
        {
            var eduDirection= await _unitOfWork.EducationDirectionRepository.GetByIdAsync(newSubject.EducationDirectionId);
            if (eduDirection == null)
            {
                return new("Ta'lim yo'nalishi topilmadi (Not found Education Direction).");
            }
            var subject= await _unitOfWork.SubjectRepository.
                    AddAsync(new(){
                        EducationDirectionId=newSubject.EducationDirectionId,
                        UserId=userId,
                        Name=newSubject.Name,
                        Image=null,
                        Description=newSubject.Description
                    });
            _unitOfWork.Save();
            return new(true){
                Data=new(){
                    Id = subject.Id,
                    EducationDirectionId = subject.EducationDirectionId,
                    Name = subject.Name,
                    Image = subject.Image,
                    Description = subject.Description,
                }
            };
        }
        catch (System.Exception e)
        {
            return new($"Fan qo'shishda xatolik yuz berdi (There was an error adding a Subject.), {e.Message}");
        }
    }

    public ValueTask<Result<Subject>> DeleteSubjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<Subject>> GetSubjectByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<List<Subject>>> GetSubjectsByEducationDirectionIdAsync(int id)
    {
        try
        {
            var subject = await _unitOfWork.SubjectRepository.
                    GetAllAsync().
                    Where(e=>e.EducationDirectionId==id).
                    ToListAsync();
            return new(true)
            {
                Data = subject.Select(e=> new Subject(){
                    Id = e.Id,
                    EducationDirectionId = e.EducationDirectionId,
                    Name = e.Name,
                    Image = e.Image,
                    Description = e.Description
                }).ToList()
            };
        }
        catch (System.Exception e)
        {
            return new($"Fanlarni olishda xatolik yuz berdi (There was an error retrieving information Subject.), {e.Message}");
            
        }
    }

    public ValueTask<Result<Subject>> UpdateSubjectAsync(int id, NewSubject newSubject)
    {
        throw new NotImplementedException();
    }
}