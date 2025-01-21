namespace Talim.Data.Entity;
public class Content : EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ContentText { get; set; }

    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public int ThemeId { get; set; }
    public int Views { get; set; }
    public virtual Theme? Theme { get; set; }
    public virtual List<ContentImage>? ContentImages { get; set; }
}