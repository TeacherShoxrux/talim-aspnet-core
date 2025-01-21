namespace  Talim.Data.Entity;
public class ContentImage : EntityBase
{
    public int ContentId { get; set; }
    public string? Title { get; set; }
    public string? Path { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}