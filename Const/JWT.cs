using Talim.Data.Entity;

namespace Talim.Const;
public  class JwtConst
{
  public JwtConst(int Id,EUserRole Role)
  {
    this.Id=Id;
    this.Role=Role;
  }
  public int Id { get; set; }  
  public EUserRole? Role { get; set; }  
}
