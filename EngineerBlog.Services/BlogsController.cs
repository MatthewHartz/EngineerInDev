using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using EngineerBlog.Data;
using EngineerBlog.Data.Models;
using EngineerBlog.Dto;

namespace EngineerBlog.Services
{
    [RoutePrefix("api")]
    public class BlogsController : ApiController
    {
        public IElasticBlogClient _client;
        public BlogsController(IElasticBlogClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Gets the latest blog.
        /// </summary>
        /// <returns></returns>
        [Route("blogs")]
        [HttpGet]
        public BlogDto GetLatestBlog()
        {
            // Get first blog

            //Create the mapping between blog and blogdto
            Mapper.CreateMap<Blog, BlogDto>();

            // Perform the conversion

            return new BlogDto();
        }

        /// <summary>
        /// Gets the blog.
        /// </summary>
        /// <returns></returns>
        [Route("blogs/{blogName}")]
        [HttpGet]
        public BlogDto GetBlog(string blogName)
        {
            // Get the specific blog

            //Create the mapping between blog and blogdto
            Mapper.CreateMap<Blog, BlogDto>();

            // Perform the conversion

            return new BlogDto();
        }

        /// <summary>
        /// Posts the blog.
        /// </summary>
        [Route("blogs")]
        [HttpPost]
        public void PostBlog()
        {
            var test = "";
        }
    }
}
