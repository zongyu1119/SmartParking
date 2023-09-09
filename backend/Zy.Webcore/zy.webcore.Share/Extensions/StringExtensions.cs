using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Extensions
{
    /// <summary>
    /// string扩展
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 获得MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMd5(this string str)
        {
            MD5 md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// 判断字符串是否为null或者为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 判断字符串是否为null或者为空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 判断字符串是否不为null或者为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 判断字符串是否不为null或者为空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrWhiteSpace(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 不区分大小写对比
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string s1, string s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
        /// <summary>
        /// 获得字符串的Base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetBase64String(this string str)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(str));
        }
    }
}
