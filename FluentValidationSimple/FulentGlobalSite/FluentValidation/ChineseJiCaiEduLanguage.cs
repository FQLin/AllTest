using FluentValidation.Validators;

namespace FulentGlobalSite.FluentValidation
{
    internal class ChineseJiCaiEduLanguage : LanguageResources
    {
        public override string Name => "zh-JC";

        public ChineseJiCaiEduLanguage()
        {
            Translate<EmailValidator>("'{PropertyName}' 不是有效的电子邮件地址。");
            Translate<GreaterThanOrEqualValidator>("'{PropertyName}' 必须大于或等于 '{ComparisonValue}'。");
            Translate<GreaterThanValidator>("'{PropertyName}' 必须大于 '{ComparisonValue}'。");
            Translate<LengthValidator>("'{PropertyName}' 的长度必须在 {MinLength} 到 {MaxLength} 字符，您已经输入了 {TotalLength} 字符。");
            Translate<MinimumLengthValidator>("'{PropertyName}' 的长度必须在 {MinLength} 到 {MaxLength} 字符，您已经输入了 {TotalLength} 字符。");
            //Translate<MaximumLengthValidator>("'{PropertyName}' 的长度必须少于 {MaxLength} 字符。");
            Translate<MaximumLengthValidator>("必须少于 {MaxLength} 字符。");
            Translate<LessThanOrEqualValidator>("'{PropertyName}' 必须小于或等于 '{ComparisonValue}'。");
            Translate<LessThanValidator>("'{PropertyName}' 必须小于 '{ComparisonValue}'。");
            Translate<NotEmptyValidator>("请填写 '{PropertyName}'。来自JiCaiEdu");
            Translate<NotEqualValidator>("'{PropertyName}' 不能和 '{PropertyValue}' 相等。");
            Translate<NotNullValidator>("请填写 '{PropertyName}'。");
            Translate<PredicateValidator>("指定的条件不符合 '{PropertyName}'。");
            Translate<AsyncPredicateValidator>("指定的条件不符合 '{PropertyName}'。");
            Translate<RegularExpressionValidator>("'{PropertyName}' 的格式不正确。");
            Translate<EqualValidator>("'{PropertyName}' 应该和 '{ComparisonValue}' 相等。");
            Translate<ExactLengthValidator>("'{PropertyName}' 必须是 {MaxLength} 个字符，您已经输入了 {TotalLength} 字符。");
            Translate<InclusiveBetweenValidator>("'{PropertyName}' 必须在 {From} 和 {To} 之间， 您输入了 {Value}。");
            Translate<ExclusiveBetweenValidator>("'{PropertyName}' 必须在 {From} 和 {To} 之外， 您输入了 {Value}。");
            Translate<CreditCardValidator>("'{PropertyName}' 不是有效的信用卡号。");
            Translate<ScalePrecisionValidator>("'{PropertyName}' 总位数不能超过 {expectedPrecision} 位，其中整数部分 {expectedScale} 位。您填写了 {digits} 位小数和 {actualScale} 位整数。");
        }
    }
}