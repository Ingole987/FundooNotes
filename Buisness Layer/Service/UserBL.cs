using Buisness_Layer.Interface;
using Common_Layer.Models;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness_Layer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserEntity Register(UserReg userReg)
        {
            try
            {
                return userRL.Register(userReg);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public UserLogin Login(UserLog userLog)
        {
            try
            {
                return userRL.Login(userLog);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ForgotPassword(string Email)
        {

            try
            {
                return userRL.ForgotPassword(Email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool ResetPassword(ResetPassword resetPassword, string email)
        {
            try
            {
                return userRL.ResetPassword( resetPassword, email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
