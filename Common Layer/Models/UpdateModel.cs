using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Layer.Models
{
    public class UpdateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
