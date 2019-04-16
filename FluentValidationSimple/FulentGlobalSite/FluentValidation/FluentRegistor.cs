using System.Globalization;
using Autofac;
using FluentValidation;
using FluentValidation.Mvc;
using System.Web.Mvc;
using FulentGlobalSite.Validator;

namespace FulentGlobalSite.FluentValidation
{
    public static class FluentRegistor
    {
        public static void Register(IContainer container)
        {
            ModelValidatorProviders.Providers.Clear();
            FluentValidationModelValidatorProvider.Configure(provider=>
            {
                //provider.ValidatorFactory = new AutofacValidatorFactory(container);
                //provider.AddImplicitRequiredValidator = true;
            });
            //ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            //替换默认错误消息
            //ValidatorOptions.LanguageManager = new ChineseJiCaiEduLanguage();
            //ValidatorOptions.LanguageManager.Enabled = true;
            //ValidatorOptions.LanguageManager.Culture = new CultureInfo("zh-JC");

            //DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            //声明验证器工厂
            //IValidatorFactory factory = new AutofacValidatorFactory(container);
            //ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(factory));
        }
    }
}