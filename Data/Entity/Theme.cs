namespace  Talim.Data.Entity;
public class Theme : EntityBase
{   
    public string? Name { get; set; }
    public string? Description { get; set; }

    public int SubjectId { get; set; }
    public virtual Subject? Subject { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public virtual ICollection<Content>? Contents { get; set; }


}

