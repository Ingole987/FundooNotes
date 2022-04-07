using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Models
{
    public class UserReg
    {
        [Required(ErrorMessage = "{0} should not be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string Password { get; set; }
    }
}
