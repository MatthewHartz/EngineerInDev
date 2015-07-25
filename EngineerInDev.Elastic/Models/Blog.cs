using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EngineerInDev.Elastic.Models
{
    public class Blog
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [DefaultValue("Matthew Hartz")]
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<string> Tags { get; set; }
        public List<Comment> Comments { get; set; }
        [DefaultValue(false)]
        public bool Hidden { get; set; }

        public Blog()
        {
            Comments = new List<Comment>();
        }
    }
}
