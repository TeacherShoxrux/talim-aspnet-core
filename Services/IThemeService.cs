using Talim.DTOs;

namespace Talim.Services;
public interface IThemeService { 

    Task<Result<List<Theme>>> GetAllThemesBySubjectIdAsync(int subjectId);
    Task<Result<ThemeContent>> GetThemeContentByIdAsync(int id);
    Task<Result<Theme>> CreateTheme(NewThemeContent newTheme);
    Task<Result<Theme>> UpdateTheme(Theme theme);
}