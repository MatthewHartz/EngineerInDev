using System.Web.Http.Dependencies;
using EngineerInDev.Elastic;
using Microsoft.Practices.Unity;
using System.Web.Http;
using EngineerInDev.DataAccess;
using Unity.WebApi;

namespace EngineerInDev
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IElasticBlogClient, ElasticBlogClient>();
            container.RegisterType<IDataAccessHelper, GithubAccessHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = (IDependencyResolver)new UnityDependencyResolver(container);
        }
    }
}