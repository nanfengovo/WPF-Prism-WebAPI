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

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <param name="Pwdagain"></param>
        /// <returns></returns>
        Task<(bool,string)> ResetPwdAsync(string Account, string Pwd,string newPwd,string Pwdagain );

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<UserDTO> GetAllUser();
    }
}
