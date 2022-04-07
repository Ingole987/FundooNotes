using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Models
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "{0} should not be empty")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string ConfirmPassword { get; set; }
    }
}
