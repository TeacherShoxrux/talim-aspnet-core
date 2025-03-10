namespace  Talim.Data.Entity;
public class Password : EntityBase{

    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }

}