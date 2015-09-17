using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Manage.Models
{

    public class UserModel
    {
        [DisplayName("ID")]
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0}不能为空")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0}不能为空")]
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("邮箱")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [DisplayName("状态")]
        [Required(AllowEmptyStrings = true)]
        public string Status { get; set; }

        [DisplayName("性别")]
        public string Sex { get; set; }

        [DisplayName("出生日期")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [DisplayName("家庭地址")]
        [Required(AllowEmptyStrings = true)]
        public string HomeAddress { get; set; }

        [DisplayName("电话号码")]
        [Required(AllowEmptyStrings = true)]
        public string Telephone { get; set; }

        [DisplayName("运营商")]
        public string Carrier { get; set; }

        [DisplayName("兴趣爱好")]
        public string[] Hobbies { get; set; }

        [DisplayName("备注")]
        [Required(AllowEmptyStrings = true)]
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }

        [DisplayName("版本号")]
        [Required(AllowEmptyStrings = true)]
        public long Version { get; set; }

        [DisplayName("创建时间")]
        [Required(AllowEmptyStrings = true)]
        public DateTime CreateTime { get; set; }

        [DisplayName("更新时间")]
        [Required(AllowEmptyStrings = true)]
        public DateTime UpdateTime { get; set; }

        [DisplayName("创建用户")]
        [Required(AllowEmptyStrings = true)]
        public long CreateUserId { get; set; }

        [DisplayName("更新用户")]
        [Required(AllowEmptyStrings = true)]
        public long UpdateUserId { get; set; }
    }

    public enum Sex
    {
        男, 女
    }

    public enum Status
    {
        激活, 未激活
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