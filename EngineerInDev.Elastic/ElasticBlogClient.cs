using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineerInDev.Elastic.Models;
using Nest;

namespace EngineerInDev.Elastic
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

        Blog GetLatestBlog();
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
            return new ElasticClient();
        }

        /// <summary>
        /// Adds the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        public void AddBlog(Blog blog)
        {
            var client = GetClient();

            client.Index(blog, b => b
                .Index("blogs"));
        }

        public Blog GetLatestBlog()
        {
            var client = GetClient();

            try
            {
                var result = client.Search<Blog>(s => s
                    .SortDescending(sort => sort
                        .CreatedOn).Take(1));
                return result.Documents.First();
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public Blog GetBlog(string name)
        {
            var client = GetClient();

            try
            {
                var result = client.Search<Blog>(s => s
                    .Query(q => q
                        .Term(p => p.Title, "About Matthew")));

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Blog> SearchBlogs(string searchText)
        {
            return new List<Blog>();
        }
    }
}
