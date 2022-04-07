using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Models
{
    public class UserLog
    {
        [Required(ErrorMessage = "{0} should not be empty")]
        //[RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+]).{8,}$", ErrorMessage = "Password  is not valid")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        //[RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+]).{8,}$", ErrorMessage = "Password  is not valid")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
