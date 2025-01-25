namespace Talim.DTOs;
public class Theme{
     public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int SubjectId { get; set; }
    public Content? ThemeContent { get; set; }

    
}
public class Content 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ContentText { get; set; }
    public int Views { get; set; }

}