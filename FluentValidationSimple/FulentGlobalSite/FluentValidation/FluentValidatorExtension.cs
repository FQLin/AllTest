using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace FulentGlobalSite.FluentValidation
{
    public static class FluentValidatorExtension
    {
        public static IRuleBuilderOptions<T, IList<TElement>> CheckboxMustChecked<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, list, context) => list != null && list.Any())
                .WithMessage("'{PropertyName}' 必须选择一个");
        }
    }
}