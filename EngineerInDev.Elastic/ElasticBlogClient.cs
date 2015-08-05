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
        List<BlogMatch> SearchBlogs(string searchText);
        List<Blog> GetAllBlogs();
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
                    .Filter(f => f
                        .Not(n => n.Query(q => q
                            .Match(m =>m
                                .OnField(oN => oN.Title.ToLower())
                                .Query("about me")))))
                    .SortDescending(sort => sort
                        .CreatedOn).Take(1));
                return result.Documents.First();
            }
            catch (Exception)
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
                        .Match(m => m
                            .OnField(f => f.Title)
                            .Query(name))));
                return result.Documents.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BlogMatch> SearchBlogs(string searchText)
        {
            var client = GetClient();

            try
            {
                var result = client
                    .Search<Blog>(s => s
                        .From(0)
                        .Size(10)
                        .Query(q => q
                            .QueryString(qs => qs
                                //.OnFields(e => e.Content, e => e.Title, e => e.Tags)
                                .OnFieldsWithBoost(b =>
                                    b.Add(f => f.Title, 10.0)
                                     .Add(f => f.Tags, 5.0)
                                     .Add(f => f.Content, 1.0))
                                .Query(searchText)
                            )
                        )
                        .Highlight(h => h
                            .OnFields(f => f
                                .OnField("*")
                                .PreTags("<b>")
                                .PostTags("</b>")
                            )
                        )
                    );

                var matches = new List<BlogMatch>();

                // sort the hits by score

                // Iterate over each hit
                foreach (var hit in result.Hits.OrderByDescending(x => x.Score).Select((value, i) => new {i, value}))
                {
                    // highlightKeyPairs is a list of guid -> [blog section -> highlight]
                    var match = new BlogMatch()
                    {
                        Blog = hit.value.Source,
                        Highlights = hit.value.Highlights
                        .Select(x => new BlogHighlightSection()
                        {
                            Section = x.Key,
                            Data = x.Value.Highlights.ToList()
                        }).ToList()
                    };
                    matches.Add(match);
                }

                return matches;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Blog> GetAllBlogs()
        {
            var client = GetClient();

            try
            {
                var result = client
                    .Search<Blog>(s => s.Query(q => q.MatchAll()));
                return result.Documents.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
