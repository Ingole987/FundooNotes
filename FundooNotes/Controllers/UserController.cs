using Buisness_Layer.Interface;
using Common_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

namespace FundooNotes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        //private readonly ILogger<UserController> logger;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
            //this.logger = logger;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserReg userReg)
        {
            try
            {
                var resUser = userBL.Register(userReg);
                if (resUser != null)
                {
                    //logger.LogInformation("Registeration Successfull");
                    return Ok(new { success = true, message = "Registeration Successfully", data = resUser });
                }
                else
                {
                    //logger.LogError("Registeration Unsuccessfull");
                    return BadRequest(new { success = false, message = "Registeration Failed EmailId Already Exist", data = resUser });
                }
            }
            catch (Exception)
            {
                //logger.LogCritical(" Exception Thrown...");
                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLog userLog)
        {
            try
            {
                var resUser = userBL.Login(userLog);
                if (resUser != null)
                {
                    //logger.LogInformation("Login Successfull");
                    return this.Ok(new { Success = true, message = "Logged In", data = resUser });
                }
                else
                {
                    //logger.LogError("Login Failed");
                    return this.BadRequest(new { Success = false, message = "Enter Valid Email and Password" });
                }
            }
            catch (Exception)
            {
                //logger.LogCritical(" Exception Thrown...");
                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var resUser = userBL.ForgotPassword(email);
                if (resUser != null)
                {
                    //logger.LogInformation("Reset Link Sent Successfull");
                    return this.Ok(new { Success = true, message = "Reset Link Sent Successfully" });
                }
                else
                {
                    //logger.LogError("Something Went Wrong");
                    return this.BadRequest(new { Success = false, message = "Enter Valid Email and Password" });
                }
            }
            catch (Exception)
            {
                //logger.LogCritical(" Exception Thrown...");
                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }

        [HttpPut("ResetPassword")]
        [Authorize]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var resUser = userBL.ResetPassword(resetPassword, email);
                if (resUser != null)
                {
                    //logger.LogInformation("Password Changed Successfully");
                    return this.Ok(new { Success = true, message = "Password Changed Successfully" });
                }
                else
                {
                    //logger.LogError("Unable to Reset Password");
                    return this.BadRequest(new { Success = false, message = "Unable to Reset Password" });
                }
            }
            catch (Exception)
            {
                //logger.LogCritical(" Exception Thrown...");
                return NotFound(new { success = false, message = " Something went wrong" });
            }
        }


    }
}


