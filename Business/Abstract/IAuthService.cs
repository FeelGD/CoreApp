using System;
using System.Collections.Generic;
using System.Text;
using Core.Dtos;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<UserLogin> RegisterLogin(UserLoginForRegisterDto userLoginForRegisterDto,string password);
        IDataResult<UserLogin> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
