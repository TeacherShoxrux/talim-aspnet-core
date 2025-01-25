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
            var oldSession = await  _unitOfWork.SessionRepository.GetAllAsync().FirstOrDefaultAsync(e=>e.UserId==e.UserId);
            if (oldSession != null)
            {
                var _= await _unitOfWork.SessionRepository.DeleteAsync(oldSession);
                _unitOfWork.Save();
            }
            var session = await _unitOfWork.SessionRepository.AddAsync(new (){
                AccessToken = _jwtService.GenerateToken(new JwtConst(passwprd.User.Id, passwprd.User.Role)), 
                UserId = passwprd.User.Id,
                RefreshToken = Guid.NewGuid(),
                ExpirationDate=DateTime.Now.AddDays(30)
                });
                _unitOfWork.Save();

            return new Result<Session>(true){
                IsSuccess = true,
                Data = new Session{
                    AccessToken = session.AccessToken,
                    RefreshToken = session.RefreshToken.ToString(),
                    ExpirationDate = session.ExpirationDate
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

    public async ValueTask<Result<UserDetails>> GetUserDetails(int id)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return new Result<UserDetails>("Foydalanuvchi topilmadi (User not found)");
            }

            return new Result<UserDetails>(true)
            {
                Data = new UserDetails
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role.ToString()
                }
            };
        }
        catch (System.Exception e)
        {
            return new($"Foydalanuvchini roʻyxatdan oʻtkazishda xatolik yuz berdi. Iltimos, qoʻllab-quvvatlash xizmatiga murojaat qiling(Error Occure While Registring user Please contact support)> {e.Message}"); 
        }
    }

    public async ValueTask<Result<UserDetails>> RegisterUser(UserRegister userRegister)
    {
         try
        {
            var passwprd = await _unitOfWork.PasswordRepository.GetAllAsync().Include(w => w.User).
                    FirstOrDefaultAsync(w => w.Email == userRegister.Email);

            if (passwprd != null)
            {
                return new ($"Ushbu {userRegister.Email} foydalanuchi allaqachon ro'yhatdan o'tgan");
            }

            var user = await _unitOfWork.UserRepository.AddAsync(
                new(){
                    LastName = userRegister.LastName,
                    FirstName = userRegister.FirstName,
                    Email = userRegister.Email,
                    Password= new  Data.Entity.Password
                    {
                        PasswordHash =  userRegister.Password.Sha256(),
                        Email = userRegister.Email
                    }
                }
            );
            _ = _unitOfWork.Save();
            return new(true){
                Data =new(){
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role =user.Role.ToString()
                }
            };
            
        }
        catch (Exception e)
        {
            
            return new($"Error Occure While Registring user Please contact support:> {e.Message}");
        }
    }
      

    public ValueTask<Result<UserDetails>> UpdateUser(UserUpdate userUpdate)
    {
        throw new NotImplementedException();
    }
}
