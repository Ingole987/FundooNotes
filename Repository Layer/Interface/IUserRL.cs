using Common_Layer.Models;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public interface IUserRL
    {
        public UserEntity Register(UserReg userReg);
        public UserLogin Login(UserLog userLog);
        public string ForgotPassword(string Email);
        bool ResetPassword(ResetPassword resetPassword, string email);
    }
}
