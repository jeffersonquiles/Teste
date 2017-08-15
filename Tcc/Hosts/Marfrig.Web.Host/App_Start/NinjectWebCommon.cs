[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Marfrig.Web.Host.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Marfrig.Web.Host.App_Start.NinjectWebCommon), "Stop")]

namespace Marfrig.Web.Host.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using WebApiContrib.IoC.Ninject;
    using Tcc.Core.BusinessRulesInterfaces;
    using Tcc.Core.BusinessRules;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System.Configuration;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity.Mvc;
    using Tcc.Core.Providers;
    using Tcc.SqlServer.Providers;
    using Tcc.Person.BusinessRulesInterfaces;
    using Tcc.Location.BusinessRulesInterfaces;
    using Tcc.Gyn.BusinessRulesInterfaces;
    using Tcc.Person.BusinessRules;
    using Tcc.Location.BusinessRules;
    using Tcc.Gyn.BusinessRules;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICoreBusinessRules>().To<CoreBusinessRules>().InRequestScope();
            kernel.Bind<IPersonBusinessRules>().To<PersonBusinessRules>().InRequestScope();
            kernel.Bind<ILocationBusinessRules>().To<LocationBusinessRules>().InRequestScope();
            kernel.Bind<IGynBusinessRules>().To<GynBusinessRules>().InRequestScope();
            kernel.Bind<CoreProviderBase>().To<CoreSqlProvider>().InRequestScope();
            kernel.Bind<PersonProviderBase>().To<PersonSqlProvider>().InRequestScope();       
            kernel.Bind<LocationProviderBase>().To<LocationSqlProvider>().InRequestScope();
            kernel.Bind<GynProviderBase>().To<GynSqlProvider>().InRequestScope();
        }
            
        //public static IUnityContainer Initialise()
        //{
        //    var container = BuildUnityContainer();

        //    DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        //    return container;
        //}

        //private static IUnityContainer BuildUnityContainer()
        //{
        //    var container = new UnityContainer();

        //    UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

        //    //Configura o Container
        //    section.Configure(container);


        //    // e.g. container.RegisterType<ITestService, TestService>();    
        //    RegisterTypes(container);

        //    return container;

        //}

        //public static void RegisterTypes(IUnityContainer container)
        //{


        //}

    }
}
