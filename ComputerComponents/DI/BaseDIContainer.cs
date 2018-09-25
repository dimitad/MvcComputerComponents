using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ComputerComponentsWeb.DI
{
    public abstract class BaseDIContainer
    {
        private Container _container;

        public TService GetInstance<TService>() where TService : class
        {
            return _container.GetInstance<TService>();
        }

        public object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public TService TryGetInstance<TService>() where TService : class
        {
            TService service = null;

            try
            {
                service = GetInstance<TService>();
            }
            catch { }

            return service;
        }

        public object TryGetInstance(Type serviceType)
        {
            object service = null;

            try
            {
                service = GetInstance(serviceType);
            }
            catch { }

            return service;
        }

        public IEnumerable<TService> GetAllInstances<TService>() where TService : class
        {
            return _container.GetAllInstances<TService>();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            IEnumerable<object> services = null;

            try
            {
                services = _container.GetAllInstances(serviceType).Cast<object>();
            }
            catch { }

            return services;
        }

        public Container Container
        {
            get { return _container; }
        }

        public virtual void BootstrapDI()
        {
            // 1. Create a new Simple Injector container
            _container = new Container();

            //1.1 Change the Constructor Resolution Behavior to greediest constructor(constructor with the most parameters).
            _container.Options.ConstructorResolutionBehavior = new GreediestConstructorBehavior();

            CustomDIRegistration(_container);

            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
        }

        protected abstract void CustomDIRegistration(Container container);

        protected abstract void CustomVerification();

    }
}