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
using System.Security.Cryptography;
using Common_Layer;

namespace Repository_Layer.Service
{
    
    public class UserRL : IUserRL
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly FundooContext fundooContext;
        private readonly IConfiguration _appSettings;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fundooContext"></param>
        /// <param name="_appSettings"></param>
        public UserRL(FundooContext fundooContext, IConfiguration _appSettings)
        {
            this.fundooContext = fundooContext;
            this._appSettings = _appSettings;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userReg"></param>
        /// <returns></returns>
        public UserEntity Register(UserReg userReg)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = userReg.FirstName;
                userEntity.LastName = userReg.LastName;
                userEntity.Email = userReg.Email;
                userEntity.Password = EncryptPassword(userReg.Password);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLog"></param>
        /// <returns></returns>
        public UserLogin Login(UserLog userLog)
        {
            try
            {
                if (string.IsNullOrEmpty(userLog.Email) || string.IsNullOrEmpty(userLog.Password))
                {
                    throw new FundooException("Email or password is incorrect");
                }
                var LoginResult = this.fundooContext.UserTable.Where(x => x.Email == userLog.Email && x.Password == userLog.Password).FirstOrDefault();
                var decryptPass = DecryptPassword(LoginResult.Password);
                if (decryptPass == userLog.Password)
                {
                    if (LoginResult != null)
                    {
                        var token = GenerateSecurityToken(LoginResult.Email, LoginResult.UserId);
                        UserLogin login = new UserLogin();

                        login.Email = LoginResult.Email;
                        login.Token = token;

                        return login;
                    }
                    else
                    {
                        return null;
                        
                    }
            }
                else
                {
                    return null;
                }

        }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
                    //return null;
                    throw new FundooException("Account not found");
                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ResetPassword(ResetPassword resetPassword , string email)
        {
            try
            {
                if (resetPassword.NewPassword.Equals(resetPassword.ConfirmPassword))
                {
                    var user = fundooContext.UserTable.Where(e => e.Email == email).FirstOrDefault();
                    user.Password = resetPassword.ConfirmPassword;
                    user.Password = EncryptPassword(user.Password);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {

                    // return false;
                    throw new FundooException("Cannot use previous Password");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string EncryptPassword(string password)
        {
            string enteredpassword = "";
            byte[] hide = new byte[password.Length];
            hide = Encoding.UTF8.GetBytes(password);
            enteredpassword = Convert.ToBase64String(hide);
            return enteredpassword;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptpwd"></param>
        /// <returns></returns>
        private string DecryptPassword(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }


    }
}



