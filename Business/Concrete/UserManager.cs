using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        IUserLoginDal _userLoginDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void AddUserLogin(UserLogin userLogin)
        {
            _userLoginDal.Add(userLogin);
        }

    
        public UserLogin GetByMail(string email)
        {
            return _userLoginDal.Get(u => u.Email == email);
        }
    }
}
