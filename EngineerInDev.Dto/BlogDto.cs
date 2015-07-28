using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EngineerInDev.Dto
{
    public class BlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<string> Tags { get; set; }
        [DefaultValue(false)]
        public bool Hidden { get; set; }
    }
}
