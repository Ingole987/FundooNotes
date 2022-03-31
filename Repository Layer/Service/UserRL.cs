using Common_Layer.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Xamarin.Essentials;
using System.IO;


namespace Repository_Layer.Service
{
    public class UserRL : IUserRL
    {
        private readonly FundooContext fundooContext;
        private readonly IConfiguration _appSettings;

        public UserRL(FundooContext fundooContext, IConfiguration _appSettings)
        {
            this.fundooContext = fundooContext;
            this._appSettings = _appSettings;
        }
        
        public UserEntity Register(UserReg userReg)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = userReg.FirstName;
                userEntity.LastName = userReg.LastName;
                userEntity.Email = userReg.Email;
                userEntity.Password = userReg.Password;
                fundooContext.UserTable.Add(userEntity);
                int res = fundooContext.SaveChanges();
                if (res > 0)
                    return userEntity;
                else
                    return null;
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
                var LoginResult = this.fundooContext.UserTable.Where(x => x.Email == userLog.Email
            && x.Password == userLog.Password).FirstOrDefault();
                if (LoginResult != null)
                {
                    var token = GenerateSecurityToken(LoginResult.Email, LoginResult.UserId);
                    UserLogin login = new UserLogin();

                    login.Email = LoginResult.Email;
                    login.Token = token;

                    return login;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string GenerateSecurityToken(string email, long userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {new Claim(ClaimTypes.Email,email),
            new Claim("UserId",userId.ToString())};
            var token = new JwtSecurityToken(
            _appSettings["Jwt:Issuer"],
            _appSettings["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string ForgotPassword(string email)
        {
            try
            {
                var Email = this.fundooContext.UserTable.Where(e => e.Email == email).FirstOrDefault();
                if (Email != null)
                {
                    var token = GenerateSecurityToken(Email.Email, Email.UserId);
                    new Msmq().SendMessage(token);
                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        public bool ResetPassword(ResetPassword resetPassword , string email)
        {
            try
            {
                if (resetPassword.NewPassword.Equals(resetPassword.ConfirmPassword))
                {
                    var user = fundooContext.UserTable.Where(e => e.Email == email).FirstOrDefault();
                    user.Password = resetPassword.ConfirmPassword;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}



