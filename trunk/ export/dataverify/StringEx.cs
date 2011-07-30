using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataVerify
{
    public static class StringEx
    {
        /// <summary>
        /// 匹配某个正则表达式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static bool IsMatch(this string str,string pattern)
        {
            return Regex.IsMatch(str, pattern);
        }

        /// <summary>
        /// 判断字符串是否为日期
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(this string str)
        {
            DateTime dt = DateTime.MinValue;
            if (!DateTime.TryParse(str, out dt))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否为正整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsUInt(this string str)
        {
            uint i = 0;
            if (!uint.TryParse(str, out i))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否为整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsInt(this string str)
        {
            int i = 0;
            if (!int.TryParse(str, out i))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否为身份证
        /// 标准：15位数字或18位数字，或17位数字加x(不区分大小写)
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsIDCard(this string str)
        {
            return Regex.IsMatch(str, @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
        }

        /// <summary>
        /// 判断字符串是否为电子邮箱
        /// 标准：w加@符号加w加.加w(其中w为字母数字或下划线)
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsEmail(this string str)
        {
            return Regex.IsMatch(str, @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*;)*");
        }

        /// <summary>
        /// 判断字符串是否为邮政编码
        /// 标准：6位数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsZipCode(this string str)
        {
            return Regex.IsMatch(str, @"^\d{6}$");
        }

        /// <summary>
        /// 判断字符串是否为QQ号码
        /// 标准：
        /// 第一位为1-9中任意数字
        /// 第二位为0-9中任意数字
        /// 且位数大于等于6
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsQQ(this string str)
        {
            return Regex.IsMatch(str, @"[1-9][0-9]{4,}");
        }

        /// <summary>
        /// 判断字符串是否为IPv4地址
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsIPv4(this string str)
        {
            return Regex.IsMatch(str, @"^[0-255].[0-255].[0-255].[0-255]$");
        }

        /// <summary>
        /// 判断字符串是否全部为大写字母
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsUpperLetter(this string str)
        {
            return Regex.IsMatch(str, "^[A-Z]+$");
        }
    }

    /// <summary>
    /// 正则表达式提示类
    /// </summary>
    public class Pattern
    {
        /// <summary>
        /// 匹配小写字母的字符串
        /// </summary>
        public const string LowerLetter = @"^[a-z]+$";
        /// <summary>
        /// 匹配数字或小写字母组成的字符串
        /// </summary>
        public const string NumberAndLetter = @"^[A-Za-z0-9]+$";
        /// <summary>
        /// 匹配数字或小写字母或下划线组成的字符串
        /// </summary>
        public const string NumberAndLetter_ = @"^\w+$";
    }
}
