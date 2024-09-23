using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivu.Data;
using Vivu.Service.Base;
using Vivu.Common;
using Vivu.Common.DTO.AuthDTO;
using Vivu.Data.Models;
using Vivu.Common.Utils.Validate;
using Vivu.Common.Utils.Enum;
using System.ComponentModel;
using System.Security.Claims;
using Vivu.Common.Utils.Encrypt;

namespace Vivu.Service
{
    public interface IAuthService
    {
        Task<IBusinessResult> Register(SignUpDTO signUpDTO);
        Task<IBusinessResult> Login(LoginDTO loginDTO);
    }
    public class AuthService : IAuthService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly DataValidate _dataValidate = new DataValidate();

        public AuthService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> Register(SignUpDTO signUpDTO)
        {
            try
            {
                if (signUpDTO == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var validateUser = await _unitOfWork.UserRepository.GetUserByUserName(signUpDTO.UserName);
                    
                    if(_dataValidate.IsValidUsername(signUpDTO.UserName) == false)
                    {
                        return new BusinessResult(Const.WARNING_INVALID_USERNAME_CODE, Const.WARNING_INVALID_USERNAME_MSG);
                    }

                    if (validateUser != null)
                    {
                        return new BusinessResult(Const.WARNING_USER_EXIST_CODE, Const.WARNING_USER_EXIST_MSG);
                    }

                    if (_dataValidate.IsValidEmail(signUpDTO.Email) == false)
                    {
                        return new BusinessResult(Const.WARNING_INVALID_EMAIL_CODE, Const.WARNING_INVALID_EMAIL_MSG);
                    }

                    validateUser = await _unitOfWork.UserRepository.GetUserByEmail(signUpDTO.Email);

                    if (validateUser != null)
                    {
                        return new BusinessResult(Const.WARNING_EMAIL_EXIST_CODE, Const.WARNING_EMAIL_EXIST_MSG);
                    }

                    if (_dataValidate.IsValidPhoneNumber(signUpDTO.PhoneNumber) == false)
                    {
                        return new BusinessResult(Const.WARNING_INVALID_PHONE_CODE, Const.WARNING_INVALID_PHONE_MSG);
                    }

                    validateUser = await _unitOfWork.UserRepository.GetUserByPhoneNumber(signUpDTO.PhoneNumber);

                    if (validateUser != null)
                    {
                        return new BusinessResult(Const.WARNING_PHONE_EXIST_CODE, Const.WARNING_PHONE_EXIST_MSG);
                    }

                    if (!_dataValidate.IsValidPassword(signUpDTO.Password))
                    {
                        return new BusinessResult(Const.WARNING_INVALID_PASSWORD_CODE, Const.WARNING_INVALID_PASSWORD_MSG);
                    }

                    var user = new User
                    {
                        Fullname = signUpDTO.Fullname,
                        PhoneNumber = signUpDTO.PhoneNumber,
                        Email = signUpDTO.Email,
                        UserName = signUpDTO.UserName,
                        Role = (int) UserRole.User,  // Assuming "User" is the default role
                        Status = 1,                  // Assuming 1 means active
                        PasswordHash = PasswordUtils.HashPassword(signUpDTO.Password), // Hash the password
                        ConcurencyStamp = Guid.NewGuid().ToString()  // Generate a new concurrency stamp
                    };

                    // Save the user to the database
                    try
                    {
                        var result = await _unitOfWork.UserRepository.CreateAsync(user);

                        if(result > 0)
                        {
                            return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                        }
                        else
                        {
                            return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                        }

                    }

                        
                    catch (Exception ex)
                    {
                        return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
                    }

                }
            }
            catch (Exception ex) 
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
            
        }

        public async Task<IBusinessResult> Login(LoginDTO loginDTO)
        {
            try
            {
                if (loginDTO == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

                var user = await _unitOfWork.UserRepository.GetUserByUserName(loginDTO.UserName);

                if (user == null)
                {
                    return new BusinessResult(Const.WARNING_USERNAME_NOT_EXIST_CODE, Const.WARNING_USERNAME_NOT_EXIST_MSG);
                }

                if (!PasswordUtils.VerifyPassword(loginDTO.Password, user.PasswordHash))
                {
                    return new BusinessResult(Const.WARNING_WRONG_PASSWROD_CODE, Const.WARNING_WRONG_PASSWROD_MSG);
                }

                try
                {
                    var token = TokenUtils.GenerateToken(user.Id, user.UserName , user.Role.ToString());

                    var refreshToken = new RefreshToken()
                    {
                        UserId = user.Id,
                        Token = token,
                        CreateBy = user.Id,
                        CreatedTime = DateTime.UtcNow,
                        ExpiresTime = DateTime.UtcNow.AddDays(1),
                        IsActive = true,
                        IsExpired = false
                    };

                    await _unitOfWork.RefreshTokenRepository.CreateAsync(refreshToken);

                    return new BusinessResult(Const.SUCCESS_LOGIN_CODE, Const.SUCCESS_LOGIN_MSG, refreshToken.Token);
                }
                catch(Exception exp) 
                {
                    Console.WriteLine($"Error: {exp.InnerException?.Message}");
                    return new BusinessResult(Const.FAIL_LOGIN_CODE, exp.Message);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        
    }
}
