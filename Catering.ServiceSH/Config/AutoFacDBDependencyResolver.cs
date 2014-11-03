using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using Autofac;

namespace Catering.ServiceSH.Config
{
    public class AutoFacDBDependencyResolver:IDbDependencyResolver
    {
        private ILifetimeScope container;

        public AutoFacDBDependencyResolver(ILifetimeScope container)
        {
            this.container = container;
        }
        
        public object GetService(Type type,object key)
        {
            return container.IsRegistered(type) ? container.Resolve(type) : null;
        }

        public IEnumerable<object> GetServices(Type type, object key)
        {
            return container.IsRegistered(type) ? new object[]{ container.Resolve(type)} : Enumerable.Empty<object>();
        }
    }
}