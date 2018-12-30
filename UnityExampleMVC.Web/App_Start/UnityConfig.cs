using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

using UnityExampleMVC.Data;
using UnityExampleMVC.DataImpl;

namespace UnityExampleMVC.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ISessionFactory, SessionFactory>();
            container.RegisterType<IRepository, Repository>();
           
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}