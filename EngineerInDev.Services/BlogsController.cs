using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using EngineerInDev.Dto;
using EngineerInDev.Elastic;
using EngineerInDev.Elastic.Models;

namespace EngineerInDev.Services
{
    [RoutePrefix("api")]
    public class BlogsController : ApiController
    {
        private IElasticBlogClient _client;
        public BlogsController(IElasticBlogClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Gets the latest blog.
        /// </summary>
        /// <returns></returns>
        [Route("blogs/newest")]
        [HttpGet]
        public BlogDto GetLatestBlog()
        {
            // Get first blog
            var blog = _client.GetLatestBlog();

            //Create the mapping between blog and blogdto
            Mapper.CreateMap<Blog, BlogDto>();

            // Perform the conversion
            return Mapper.Map<BlogDto>(blog);
        }

        /// <summary>
        /// Gets the blog.
        /// </summary>
        /// <returns></returns>
        [Route("blogs")]
        [HttpGet]
        public BlogDto GetBlog(string name)
        {
            // Get the specific blog
            var blog = _client.GetBlog(name);

            //Create the mapping between blog and blogdto
            Mapper.CreateMap<Blog, BlogDto>();

            // Perform the conversion
            return Mapper.Map<BlogDto>(blog);
        }

        /// <summary>
        /// Posts the blog.
        /// </summary>
        [Route("blogs")]
        [HttpPost]
        public void PostBlog([FromBody]BlogDto blog)
        {
            //Create the mapping between blog and blogdto
            Mapper.CreateMap<BlogDto, Blog>();
            _client.AddBlog(Mapper.Map<Blog>(blog));
        }
    }
}
