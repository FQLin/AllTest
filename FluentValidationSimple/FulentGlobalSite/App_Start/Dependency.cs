using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using System.Reflection;
using System.Web.Mvc;
using FulentGlobalSite.Validator.Account;

namespace FulentGlobalSite
{
    public class Dependency
    {
        private static IContainer _container;

        /// <summary>
        /// 注册业务层接口
        /// </summary>
        public static IContainer RegisterType()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册mvc容器的实现  

            //Fluent Validator
            AssemblyScanner
                .FindValidatorsInAssemblyContaining<LoginViewModelValidator>()
                .ForEach(x => builder.RegisterType(x.ValidatorType).As(x.InterfaceType).SingleInstance());
            builder.RegisterFilterProvider();
            _container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));//注册MVC容器  
            return _container;
        }
    }
}