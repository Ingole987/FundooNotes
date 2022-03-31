using Common_Layer.Models;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Interface
{
    public interface IUserBL
    {
        public UserEntity Register(UserReg userReg);
        public UserLogin Login(UserLog userLog);
        public string ForgotPassword(string Email);
        public bool ResetPassword(ResetPassword resetPassword, string email);

    }
}
