using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerBlog.Data.Models
{
    public class Comment
    {
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}
