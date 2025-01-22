using Talim.DTOs;

namespace Talim.Services;

public interface IUserService
{
    ValueTask<UserDetails> ForgetPassword(UserLogin userLogin);
    ValueTask<Session> Authenticate(UserLogin userLogin);

    ValueTask<UserDetails> GetUserDetails(int id);

    ValueTask<UserDetails> UpdateUser(UserUpdate userUpdate);

    ValueTask<UserDetails> RegisterUser(UserRegister userRegister);

}
