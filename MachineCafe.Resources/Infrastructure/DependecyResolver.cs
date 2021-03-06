﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Extensions.ChildKernel;
using Ninject.Modules;

namespace MachineCafe.WebApi.Infrastructure
{
    public class NinjectResolver : IDependencyResolver, IDependencyScope
    {
        private INinjectModule[] _requestScopedConfigurations;
        private readonly IKernel _kernel;

        public NinjectResolver(params INinjectModule[] singletonConfigurations)
        {
            this._kernel = new StandardKernel(singletonConfigurations);
        }

        private NinjectResolver(IKernel kernel)
        {
            this._kernel = kernel;
        }
        public void AddRequestScopedModules(params INinjectModule[] modules)
        {
            _requestScopedConfigurations = modules;
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return this._kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._kernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            if (_requestScopedConfigurations != null && _requestScopedConfigurations.Length > 0)
                return new NinjectResolver(new ChildKernel(this._kernel, _requestScopedConfigurations));
            else
                return new NinjectResolver(new ChildKernel(this._kernel));
        }
    }

   
}