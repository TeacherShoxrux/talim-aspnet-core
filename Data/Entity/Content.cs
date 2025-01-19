namespace  Talim.Data.Entity;

public class Content
{
    public int ContentId { get; set; }
    public int ThemeId { get; set; }
    public Theme Theme { get; set; }
    public string Title { get; set; }
    public string ContentText { get; set; }  // Store content as HTML or Markdown
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
