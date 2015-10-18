﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EngineerInDev.Elastic.Models;

namespace EngineerInDev.DataAccess
{
    public class GithubAccessHelper : IDataAccessHelper
    {
        public string GetToken()
        {
            return ConfigurationManager.AppSettings["GithubToken"];
        }

        public string GetReposUrl()
        {
            return ConfigurationManager.AppSettings["GithubBlogs"];
        }

        public List<Blog> GetBlogs()
        {
            var token = GetToken();
            var url = GetReposUrl();

            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query["access_token"] = token;
            uriBuilder.Query = query.ToString();

            var client = new WebClient();
            client.Headers.Add("user-agent", "Engineer In Dev");

            // Get the directories within the Repos directory of the project
            var content = client.DownloadString(uriBuilder.ToString());




            return new List<Blog>();
        }
    }
}
