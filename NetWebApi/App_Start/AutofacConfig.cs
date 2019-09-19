using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace QWZE.JF
{
    public class AutofacConfig
    {
        public static void Register()
        {
            //----AutoFac  DI------
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());               //RegisterApiControllers方法
            var container = builder.Build();
            HttpConfiguration config = GlobalConfiguration.Configuration;//注意此处HttpConfiguration类的 config对象，一定不要new,要从GlobalConfiguration获取
            config.DependencyResolver = (new AutofacWebApiDependencyResolver(container));      //注意此处与MVC依赖注入不同
        }

        private static void SetupResolveRules(ContainerBuilder builder)
        {
            var assembly = Assembly.Load("QWZE.JF");

            //注册所有实现了 IDependency 接口的类型
            System.Type baseType = typeof(BLL.IDependency);
            builder.RegisterAssemblyTypes(assembly)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsSelf().AsImplementedInterfaces()
                .PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly).SingleInstance();//每次都返回同一个实例
            // 注册一个用于测试的组件。
            //builder.RegisterType<DAL.PersonDal>().As<BLL.ITest>();
        }
    }
}