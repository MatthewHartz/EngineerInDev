using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EngineerInDev.Elastic.Models;

namespace EngineerInDev.Dto
{
    public static class AutoMapperBlogConfiguration
    {
        public static void Configure()
        {
            ConfigureBlogMapping();
        }

        public static void ConfigureBlogMapping()
        {
            Mapper.CreateMap<BlogHighlightSection, BlogHighlightSectionDto>();
            Mapper.CreateMap<BlogMatch, BlogMatchDto>();
            Mapper.CreateMap<Blog, BlogDto>();
        }
    }
}
