using System.Collections.Generic;
using EngineerInDev.Elastic.Models;

namespace EngineerInDev.DataAccess
{
    public interface IDataAccessHelper
    {
        string GetToken();
        List<Blog> GetBlogs();
    }
}