using Microsoft.EntityFrameworkCore;
using Talim.DTOs;
using Talim.Repositories;

namespace Talim.Services;
public class ThemeService : IThemeService
{
    private readonly IUnitOfWork _unitOfWork;

    public ThemeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Theme>> CreateTheme(int userId,NewThemeContent newTheme)
    {
        try
        {
            var theme = await _unitOfWork.
                    ThemeRepository.
                    AddAsync(new(){
                        UserId=userId,
                        SubjectId=newTheme.SubjectId,
                        Name=newTheme.Name,
                        Description="",
                        Contents = new List<Data.Entity.Content>(){
                            new (){
                              Name= newTheme.Name,
                              ContentText=newTheme.ContentText,
                              UserId=userId,
                            }}
                       
                    });
            _unitOfWork.Save();
            
            var conts = theme.Contents?? new List<Data.Entity.Content>();
            Content? themeContent = null;
            if (conts.Count != 0)
            {
                var cont=conts.First();
                themeContent = new Content(){
                Id= cont.Id,
                Name=cont.Name,
                ContentText=cont.ContentText,
                Views=cont.Views
             };
            }  
            
            
            return new(true){
                Data=new(){
                    Id=theme.Id,
                    Description=theme.Description,
                    Name=theme.Name,
                    SubjectId=theme.SubjectId,
                    ThemeContent=themeContent
                }
            };
        }
        catch (System.Exception e)
        {
            
            return new($"Mavzu matnlari qo'shishda xatolik yuz berdi tekshirib koring (There was an error adding subject lines, please check.).{e.Message}");
        }
    }

    public async Task<Result<List<Theme>>> GetAllThemesBySubjectIdAsync(int subjectId)
    {
        try
        {
        var themes= await _unitOfWork.ThemeRepository.GetAllAsync().Where(e=>e.SubjectId==subjectId).ToListAsync();
        return new(true)
            {
            Data = themes.Select(e=> new Theme(){
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                SubjectId = e.SubjectId,
            }).ToList()
            };
        }
        catch (System.Exception e)
        {
            
           return new($"Fan Mavzularini olishda xatolik yuz berdi (There was an error retrieving Subject Theme).{e.Message}");
        }
    }

    public async Task<Result<ThemeContent>> GetContentByThemeIdAsync(int id)
    {
        try
        {
            var content= await _unitOfWork.ContentRepository.GetAllAsync().FirstOrDefaultAsync(e=>e.ThemeId==id);
            if(content != null)
            {
                content.Views++;
               content = await _unitOfWork.ContentRepository.UpdateAsync(content);
                return new(true){
                    Data = new(){
                        Id = content.Id,
                        Name = content.Name,
                        ContentText = content.ContentText,
                        Views = content.Views,
                        ThemeId = content.ThemeId
                    }
                };
            }
             return new($"Berilgan Id bo'yicha mavzu topilmadi (No topic found with the given ID.)");
        }
        catch (System.Exception e)
        {
            
           return new($"Mavzu matnini olishda xatolik yuz berdi (There was an error retrieving the subject text).{e.Message}");

        }
    }

    public Task<Result<Theme>> UpdateTheme(Theme theme)
    {
        throw new NotImplementedException();
    }
}