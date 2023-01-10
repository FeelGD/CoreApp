using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Dtos;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userLoginService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userLoginService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var user = new User
            {
                //Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                //PasswordHash = passwordHash,
                //PasswordSalt = passwordSalt,
                Status = true
            };
            //ToDo userLogin
            _userLoginService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }
        public IDataResult<UserLogin> RegisterLogin(UserLoginForRegisterDto userLoginForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var userLogin = new UserLogin
            {
                UserId = userLoginForRegisterDto.UserId,
                Email = userLoginForRegisterDto.Email,
                //FirstName = userForRegisterDto.FirstName,
                //LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var user=_userLoginService.Get(c=> c.)
            _userLoginService.AddUserLogin(userLogin);
            return new SuccessDataResult<UserLogin>(userLogin, Messages.UserRegistered);
        }

        public IDataResult<UserLogin> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userLoginService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<UserLogin>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<UserLogin>(Messages.PasswordError);
            }

            return new SuccessDataResult<UserLogin>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userLoginService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userLoginService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
