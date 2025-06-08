using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.Domain.IServe
{
    public interface IRoleManageServe
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        Task<(bool Success, string Msg)> AddRoleAsync(string RoleName);
    }
}
