using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Models
{
    public class NotesCollab
    {
        [Required(ErrorMessage = "{0} should not be empty")]
        //[RegularExpression(@"^[a-zA-Z0-9]{3,}([._+-][a-zA-Z0-9]{1,})?@[a-zA-Z0-9]{1,10}[.][a-zA-Z]{2,3}([.][a-zA-Z]{2,3})?$", ErrorMessage = "Email Id is not valid")]
        //[DataType(DataType.EmailAddress)]
        public string CollabEmailId { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Note Id Should be Greater than zero number")]
        public long NoteId { get; set; }
    }
}
