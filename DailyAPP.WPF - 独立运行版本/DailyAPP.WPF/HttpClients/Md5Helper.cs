using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.HttpClients
{
    /// <summary>
    /// MD5加密工具类
    /// </summary>
    public class Md5Helper
    {
        /// <summary>
        /// MD5 UTF-8 32位加密
        /// </summary>
        /// <param name="content">明文</param>
        /// <returns>md5结果</returns>
        public static string GetMd5(string content)
        {
            return string.Join("",MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(content)).Select(x => x.ToString("x2")));
        }
    }
}
