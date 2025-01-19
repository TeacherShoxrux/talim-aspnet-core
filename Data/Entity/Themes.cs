namespace Talim.Data.Entity;

using Talim.Data.Entity;

public class Theme
{
    public int ThemeId { get; set; }
    public string Name { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public ICollection<Content> Contents { get; set; }
}
