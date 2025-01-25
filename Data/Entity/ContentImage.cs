namespace  Talim.Data.Entity;
public class ContentImage : EntityBase
{

    public string? Title { get; set; }
    public string? Path { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public int ContentId { get; set; }=1;
    public virtual Content? Content { get; set; }
}