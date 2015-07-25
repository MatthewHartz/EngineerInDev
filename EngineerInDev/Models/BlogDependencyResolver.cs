using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace EngineerInDev.Unity
{
    public class BlogDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public BlogDependencyResolver(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                throw new ArgumentNullException("container");
            }
            _unityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
    }
}
