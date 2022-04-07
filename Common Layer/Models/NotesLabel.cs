using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.Models
{
    public class NotesLabel
    {
        [Required(ErrorMessage = "{0} should not be empty")]
        public string Label { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Note Id Should be Greater than zero number")]
        public long NoteId { get; set; }
    }
}
