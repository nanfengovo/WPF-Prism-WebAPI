using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.DTOs
{
    /// <summary>
    /// 账户DTO
    /// </summary>
    public class AccountInfoDTO
    {
        /// <summary>
        /// 账号名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 再次输入密码
        /// </summary>
        public string ConfrmPwd { get; set; }
    }
}
