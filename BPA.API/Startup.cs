using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using BPAClassLibrary;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Repository;
using Ninject;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(BPA.API.Startup))]

namespace BPA.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);
            WebApiConfig.Register(config);
            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(config);
        }


        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            // Repository bindings here
            kernel.Bind<IBackboneRepository>().To<BackboneRepository>();
            kernel.Bind<IDataElementRepository>().To<DataElementRepository>();
            kernel.Bind<IBackbonePageElementRepository>().To<BackbonePageElementRepository>();
            kernel.Bind<IBackbonePageIdentifierRepository>().To<BackbonePageIdentifierRepository>();
            kernel.Bind<IPageTypeRepository>().To<PageTypeRepository>();
            kernel.Bind<IBackbonePageElementIdentifierRepository>().To<BackbonePageElementIdentifierRepository>();   
            return kernel;
        }
    }
}
