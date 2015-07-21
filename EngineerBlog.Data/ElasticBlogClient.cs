using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineerBlog.Data.Models;
using Nest;

namespace EngineerBlog.Data
{
    public interface IElasticBlogClient
    {
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <returns></returns>
        ElasticClient GetClient();

        /// <summary>
        /// Adds the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        void AddBlog(Blog blog);

        Blog GetMostRecentBlog();
        Blog GetBlog(string name);
        List<Blog> SearchBlogs(string searchText);
    }

    public class ElasticBlogClient : IElasticBlogClient
    {
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <returns></returns>
        public ElasticClient GetClient()
        {
            var node = new Uri("http://localhost:9200");

            var settings = new ConnectionSettings(
                node
            );
            return new ElasticClient(settings);
        }

        /// <summary>
        /// Adds the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        public void AddBlog(Blog blog)
        {
            var client = GetClient();

            var index = client.Index(blog);
        }

        public Blog GetMostRecentBlog()
        {
            var client = GetClient();

            return new Blog();
        }

        public Blog GetBlog(string name)
        {
            var client = GetClient();

            return new Blog();
        }

        public List<Blog> SearchBlogs(string searchText)
        {
            return new List<Blog>();
        } 
    }
}
