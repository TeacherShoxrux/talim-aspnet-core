namespace  Talim.Data.Entity;
public class Theme : EntityBase
{   
    public string? Name { get; set; }

    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public List<Content>? Contents { get; set; }


}

