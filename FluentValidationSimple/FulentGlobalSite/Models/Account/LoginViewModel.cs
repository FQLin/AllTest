using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using FulentGlobalSite.Validator.Account;

namespace FulentGlobalSite.Models.Account
{
    [Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {
        [Key]
        public string Id { get; set; }
        
        [DisplayName("用户名")]
        //[StringLength(50,ErrorMessage = "来自StringLength的错误信息")]
        public string UserName { get; set; }
        [DisplayName("密码")]
        //[StringLength(50, ErrorMessage = "来自StringLength的错误信息")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [DisplayName("验证码")]
        public string Code { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}