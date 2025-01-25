namespace Talim.DTOs;
public class Session
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public  DateTime ExpirationDate { get; set; }

}