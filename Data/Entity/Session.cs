namespace  Talim.Data.Entity;
public class Session : EntityBase {

    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime ExpirationDate { get; set; }

}