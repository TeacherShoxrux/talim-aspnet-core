using Talim.DTOs;

namespace Talim.Services;
public interface IThemeService { 

    Task<List<Theme>> GetAllThemesBySubjectIdAsync(int subjectId);
    Task<ThemeContent> GetThemeContentByIdAsync(int id);
    Task<Theme> CreateTheme(NewThemeContent newTheme);
    Task<Theme> UpdateTheme(Theme theme);
}