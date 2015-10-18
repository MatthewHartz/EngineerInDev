using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using EngineerInDev.DataAccess;
using EngineerInDev.Dto;
using EngineerInDev.Elastic;
using EngineerInDev.Elastic.Models;

namespace EngineerInDev.Services
{
    [RoutePrefix("api")]
    public class BlogsController : ApiController
    {
        private IElasticBlogClient _client;
        private IDataAccessHelper _helper;

        public BlogsController(IElasticBlogClient client, IDataAccessHelper helper)
        {
            _client = client;
            _helper = helper;
        }

        /// <summary>
        /// Gets the latest blog.
        /// </summary>
        /// <returns></returns>
        [Route("blogs/archive")]
        [HttpGet]
        public List<BlogDto> GetArchivedBlogs()
        {
            //// Get first blog
            //var blogs = _client.GetAllBlogs();

            //// group blogs by month and year
            //var calendar = blogs.GroupBy(blog => blog.CreatedOn.Year,
            //                             (key, g) => new
            //{
            //    Year = key,
            //    Blogs = Mapper.Map<List<BlogDto>>(g.ToList().OrderByDescending(d => d.CreatedOn))
            //})
            //.OrderByDescending(d => d.Year).ToList();

            //// Perform the conversion
            //return new List<object>(calendar);
            _helper.GetBlogs();

            return new List<BlogDto>();
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

            // Perform the conversion
            return Mapper.Map<BlogDto>(blog);
        }

        /// <summary>
        /// Gets the blog.
        /// </summary>
        /// <returns></returns>
        [Route("blogs")]
        [HttpGet]
        public HttpResponseMessage GetBlog(string name)
        {
            // Get the specific blog
            var blog = _client.GetBlog(name);

            if (blog == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            // Perform the conversion
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<BlogDto>(blog));
        }

        /// <summary>
        /// Gets the blog.
        /// </summary>
        /// <returns></returns>
        [Route("blogs/search")]
        [HttpGet]
        public HttpResponseMessage Search(string query)
        {
            // Get the specific blog
            var results = _client.SearchBlogs(query);

            if (results == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            // Perform the conversion
            //return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<BlogMatchDto>(results));
            return Request.CreateResponse(HttpStatusCode.OK,
                Mapper.Map<List<BlogMatchDto>>(results));
        }

        /// <summary>
        /// Posts the blog.
        /// </summary>
        [Route("blogs")]
        [HttpPost]
        [BasicAuthenticationAttribute("rvbmrdonut", "My Password For Engineer In Dev1", BasicRealm = "EngineerInDev")]
        public void PostBlog([FromBody]BlogDto blog)
        {
            _client.AddBlog(Mapper.Map<Blog>(blog));
        }
    }
}
