using Autofac;
using FluentValidation;
using System;

namespace FulentGlobalSite.Validator
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;

        public AutofacValidatorFactory(IContainer container)
        {
            this._container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            object instance;
            if (this._container.TryResolve(validatorType, out instance))
            {
                var validator = instance as IValidator;
                return validator;
            }
            return null;
        }
    }
}