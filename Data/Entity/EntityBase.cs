namespace  Talim.Data.Entity;
public class EntityBase{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }=DateTime.Now;
    public DateTime? UpdatedAt { get; set; }=DateTime.Now;

}