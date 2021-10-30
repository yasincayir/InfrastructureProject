using CoreLayer.Entities.Concrete;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Security.JWT;
using EntitiesLayer.ComplexType;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
