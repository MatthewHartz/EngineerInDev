using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerInDev.Elastic.Models
{
    public class Comment
    {
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
        [DefaultValue(false)]
        public bool Hidden { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}
