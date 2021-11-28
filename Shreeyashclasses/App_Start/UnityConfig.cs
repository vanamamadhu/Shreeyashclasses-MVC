using Shreeyashclasses.Shreeyash.DAC;
using Shreeyashclasses.Shreeyash.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Shreeyashclasses
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IValidation, Validation>();
            container.RegisterType<IRegistration, Registration>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}