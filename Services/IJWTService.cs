using Talim.Const;

namespace Talim.Services;
public interface IJWTService
{
    string GenerateToken(JwtConst calims);
    JwtConst? Authenticate (HttpContext httpContext);
}