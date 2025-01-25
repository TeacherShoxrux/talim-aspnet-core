namespace Talim.DTOs;
public class ThemeContent{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ContentText { get; set; }
    public int Views { get; set; }
    public int ThemeId { get; internal set; }
}