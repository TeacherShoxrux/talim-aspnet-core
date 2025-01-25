using Talim.DTOs;

namespace Talim.Services;

public interface IUserService
{
    ValueTask<Result<UserDetails>> ForgetPassword(UserLogin userLogin);
    ValueTask<Result<Session>> Authenticate(UserLogin userLogin);

    ValueTask<Result<UserDetails>> GetUserDetails(int id);

    ValueTask<Result<UserDetails>> UpdateUser(UserUpdate userUpdate);

    ValueTask<Result<UserDetails>> RegisterUser(UserRegister userRegister);

}
