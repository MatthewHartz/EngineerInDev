using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerInDev.Elastic.Models
{
    public class BlogMatch
    {
        public Blog Blog { get; set; }
        public List<BlogHighlightSection> Highlights { get; set; }
    }
}
