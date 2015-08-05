using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerInDev.Dto
{
    public class BlogMatchDto
    {
        public BlogDto Blog { get; set; }
        public List<BlogHighlightSectionDto> Highlights { get; set; }
    }
}
