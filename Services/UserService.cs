using Microsoft.EntityFrameworkCore;
using Talim.Const;
using Talim.DTOs;
using Talim.Repositories;
using Talim.Utils;

namespace Talim.Services;
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJWTService _jwtService;

    public UserService(IUnitOfWork unitOfWork, IJWTService jwtService)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async ValueTask<Result<Session>> Authenticate(UserLogin userLogin)
    {
        try
        {
             var passwprd = await _unitOfWork.PasswordRepository.GetAllAsync().Include(w => w.User).
                    FirstOrDefaultAsync(w => w.Email == userLogin.Email && w.PasswordHash == userLogin.Password.Sha256());

            if (passwprd == null)
            {
                return new Result<Session>("Invalid Email or Password");
            }

            var session = await _unitOfWork.SessionRepository.AddAsync(new (){
                AccessToken = _jwtService.GenerateToken(new JwtConst(passwprd.User.Id, passwprd.User.Role)), 
                UserId = passwprd.User.Id,
                RefreshToken = Guid.NewGuid(),
                });

            return new Result<Session>(true){
                IsSuccess = true,
                Data = new Session{
                    AccessToken = session.AccessToken,
                    RefreshToken = session.RefreshToken.ToString()

                }
            };
        }
        catch (Exception e)
        {
            
            return new Result<Session>(e.Message);
        }
       
        
    }

    public ValueTask<Result<UserDetails>> ForgetPassword(UserLogin userLogin)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<UserDetails>> GetUserDetails(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<UserDetails>> RegisterUser(UserRegister userRegister)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<UserDetails>> UpdateUser(UserUpdate userUpdate)
    {
        throw new NotImplementedException();
    }
}
