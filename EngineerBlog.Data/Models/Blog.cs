using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerBlog.Data.Models
{
    public class Blog
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<string> Tags { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}
