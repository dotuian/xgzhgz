using Manage.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Manage.Models
{

    public class UserModel : IValidatableObject
    {
        [DisplayName("ID")]
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0}不能为空！")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "{0}的长度必须在{2}到{1}之间！")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0}不能为空！")]
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0}不能为空！")]
        [DisplayName("确认密码")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密码不一致！")]
        public string ConfirmPassword { get; set; }

        //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayName("邮箱")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [DisplayName("状态")]
        [Required(AllowEmptyStrings = true)]
        public string Status { get; set; }

        [DisplayName("性别")]
        [Sex(ErrorMessage = "请输入选择正确的性别！")]
        public string Sex { get; set; }

        [DisplayName("角色")]
        public Role Role { get; set; }

        [UIHint("EnumDropDownList")] //通过 UIHint 指定要EditorFor渲染该字段的模板文件名（Views/Shared/EditorTemplates）
        [DisplayName("国家")]
        public Country Country { get; set; }

        [DisplayName("出生日期")]
        [PastDate(ErrorMessage = "请输入过去的日期！")] // 过去的日期
        public string Birthday { get; set; }

        [DisplayName("家庭地址")]
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)] //不允许将空字符串转换为null
        public string HomeAddress { get; set; }

        [DisplayName("电话号码")]
        [Required(AllowEmptyStrings = true)]
        public string Telephone { get; set; }

        [DisplayName("运营商")]
        [ValueRange(Range = new string[] { "au", "softbank" }, ErrorMessage = "{0}无效的选项！")]
        public string Carrier { get; set; }

        [DisplayName("兴趣爱好")]
        public string[] Hobbies { get; set; }

        [DisplayName("备注")]
        [Required(AllowEmptyStrings = true)]
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }

        [DisplayName("版本号")]
        [Range(0, 10000)]
        public long Version { get; set; }

        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }

        [DisplayName("更新时间")]
        public DateTime UpdateTime { get; set; }

        [DisplayName("创建用户")]
        public long CreateUserId { get; set; }

        [DisplayName("更新用户")]
        public long UpdateUserId { get; set; }

        //IValidatableObject接口的实现
        //定义Model的验证逻辑
        //只有当元数据指定特性的验证全部通过之后，才会执行到该方法中进行验证
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.UserName.ToLower() == "admin") {
                errors.Add(new ValidationResult("系统保留用户名，请使用其他用户名"));
            }

            if (this.Sex != "M" && this.Sex != "F")
            {
                errors.Add(new ValidationResult("请输入正确的性别"));
            }

            if (this.Carrier != "au" && this.Carrier != "softbank" && this.Carrier != "docomo") {
                errors.Add(new ValidationResult("请选择正确的运营商！"));
            }

            return errors;
        }
    }

    public enum Sex
    {
        男, 女
    }

    public enum Status
    {
        激活, 未激活
    }

    public enum Country {
        中国, 日本, 美国
    }


    // @Html.CheckBoxListFor 范例 http://mvccbl.com/Examples
    public class Hobby
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    public class KV {
        public string Code { get; set; }
        public string Name { get; set; }
    }


    // 创建用户ViewModel
    public class CreateUserViewModel
    {
        public UserModel User { get; set; }

        // 兴趣爱好
        public IList<Hobby> AvailableHobbies { get; set; }
        public IList<Hobby> SelectedHobbies { get; set; }

        // 运营商
        public IList<KV> CarriersList { get; set; }
    }
}