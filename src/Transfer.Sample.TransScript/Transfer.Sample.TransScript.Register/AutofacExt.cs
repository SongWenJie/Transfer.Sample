using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using Transfer.Sample.TransScript.BLL;
using Transfer.Sample.TransScript.DAL;
using Transfer.Sample.TransScript.IBLL;
using Transfer.Sample.TransScript.IDAL;

namespace Transfer.Sample.TransScript.Register
{
    public  static class AutofacExt
    {
        private static IContainer _container;
        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<AccountService>().As<IAccountService>().PropertiesAutowired();
            //builder.RegisterType<AccountRepository>().As<IAccountRepository>().PropertiesAutowired();

            //var iService = Assembly.Load("Transfer.Sample.TransScript.IBLL");
            //var service = Assembly.Load("Transfer.Sample.TransScript.BLL");
            //builder.RegisterAssemblyTypes(iService, service).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

            //注册业务逻辑层
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();

            //注册仓储层
            builder.RegisterAssemblyTypes(typeof(AccountRepository).Assembly)
           .Where(t => t.Name.EndsWith("Repository"))
           .AsImplementedInterfaces();

            // 注册controller，使用属性注入
            //builder.RegisterControllers(Assembly.GetCallingAssembly()).PropertiesAutowired();
            // 注册apicontroller，使用属性注入
            builder.RegisterApiControllers(Assembly.GetCallingAssembly()).PropertiesAutowired();

            _container = builder.Build();

            //Set the MVC DependencyResolver
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

            //Set the WebApi DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)_container);
        }
    }
}
