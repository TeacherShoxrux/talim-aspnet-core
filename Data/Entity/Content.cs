namespace Talim.Data.Entity;
public class Content
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ContentText { get; set; }
    public int ThemeId { get; set; }
    public Theme? Theme { get; set; }
    public List<ContentImage>? ContentImages { get; set; }
}