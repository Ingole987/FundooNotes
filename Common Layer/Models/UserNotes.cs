using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Models
{
    public class UserNotes
    {
        [Required(ErrorMessage = "{0} should not be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public DateTime Reminder { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string Color { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string Image { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public bool IsArchive { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public bool IsTrash { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public bool IsPinned { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public DateTime ModifiedAt { get; set; }
    }
}
