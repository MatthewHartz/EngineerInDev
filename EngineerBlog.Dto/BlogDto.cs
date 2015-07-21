using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerBlog.Dto
{
    public class BlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<string> Tags { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
