using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;
using OSBB.Controllers;
using OSBB.Repositories;
using OSBB.Services;

namespace OSBB.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IHouseRepository, HouseRepository>();
            container.RegisterType<IHouseService, HouseService>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}