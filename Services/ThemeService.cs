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

    public async Task<Result<Theme>> UpdateTheme(int userId,NewThemeContent newTheme)
    {
        try
        {

            var theme = await _unitOfWork.ThemeRepository.GetByIdAsync(newTheme.ThemeId);
            if (theme == null)
            {
                return new("Mavzu ID si topilmadi(Theme ID not found).");
            }
            var content = await _unitOfWork.ContentRepository.GetByIdAsync(newTheme.ContentId);
            if (content == null)
            {
                return new("(Content ID not found).");
            }
            theme.IsDraft=false;
            theme.Name=newTheme.Name;
            theme.UpdatedAt=DateTime.Now;
            content.UpdatedAt=DateTime.Now;
            content.ContentText=newTheme.ContentText;
            content.Name=newTheme.Name;
           content = await _unitOfWork.ContentRepository.UpdateAsync(content);
           theme = await _unitOfWork.ThemeRepository.UpdateAsync(theme);
           _unitOfWork.Save();
            return new(true){
                Data=new(){
                    Id=theme.Id,
                    Description=theme.Description,
                    Name=theme.Name,
                    CreatedAt=theme.CreatedAt,
                    UpdatedAt=theme.UpdatedAt,
                    SubjectId=theme.SubjectId,
                    ThemeContent=new (){
                        Id=content.Id,
                        ContentText=content.ContentText,
                        Name=content.Name,
                        CreatedAt=content.CreatedAt,
                        UpdatedAt=content.UpdatedAt,
                    }
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

    public async Task<Result<Theme>> CreateTheme(int userId, int subjectId)
    {
        try
        {
            var draftTheme = await _unitOfWork.
                    ThemeRepository.
                    GetAllAsync().
                    Include(t=>t.Contents).
                    FirstOrDefaultAsync(e=>e.SubjectId==subjectId && e.UserId==userId && e.IsDraft);
            if (draftTheme != null)
            {
                var conts = draftTheme.Contents?? new List<Data.Entity.Content>();
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
                    Id=draftTheme.Id,
                    Description=draftTheme.Description,
                    Name=draftTheme.Name,
                    SubjectId=draftTheme.SubjectId,
                    ThemeContent=themeContent
                }
                };
            }
            else{
                var theme = await _unitOfWork.
                    ThemeRepository.
                    AddAsync(new(){
                        UserId=userId,
                        SubjectId=subjectId,
                        Name="Mavzu nomi",
                        Description="",
                        IsDraft=true,
                        Contents = new List<Data.Entity.Content>(){
                            new (){
                              Name= "Mavzu nomi",
                              ContentText="Mavzu matni",
                              UserId=userId,
                              IsDraft=true
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
            
           
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}