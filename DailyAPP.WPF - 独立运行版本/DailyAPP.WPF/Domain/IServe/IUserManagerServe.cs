using DailyAPP.WPF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.Domain.IServe
{
    public interface IUserManagerServe
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<(bool,string)> AddUserAsync(AccountInfoDTO account);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<(bool, string)> LoginAsync(string Account,string Pwd);    
    }
}
