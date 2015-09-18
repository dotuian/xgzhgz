using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// 自定义验证特性
/// </summary>
namespace Manage.Validations
{
    /// <summary>
    /// 性别验证的特性类
    /// </summary>
    public class SexAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string sex = value as string;
            return "M".Equals(sex) || "F".Equals(sex);
        }
    }

    /// <summary>
    /// 过去日期验证器
    /// </summary>
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime parsedDate;
            string dateValue = value as string;

            if (DateTime.TryParseExact(dateValue, "yyyy-MM-dd", null, DateTimeStyles.None, out parsedDate))
            {
                Console.WriteLine("Converted '{0}' to {1:d}.", dateValue, parsedDate);

                return parsedDate.CompareTo(DateTime.Now) < 0;
            }
            else {
                //日期解析失败
                return false;
            }

        }
    }

    /// <summary>
    /// 指定范围值验证器
    /// </summary>
    public class ValueRangeAttribute : ValidationAttribute {

        public string[] Range { get; set; }

        public override bool IsValid(object value)
        {
            return Range.Contains(value as string);
        }


    }



}