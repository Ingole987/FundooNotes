using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Layer.Models
{
    public class UserNotes
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Reminder { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        public bool IsTrash { get; set; }
        public bool IsPinned { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
