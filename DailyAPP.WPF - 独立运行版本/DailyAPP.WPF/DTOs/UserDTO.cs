using DailyAPP.WPF.EntityFrameCore.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.DTOs
{
    public class UserDTO
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>(); // 通过关联表导航

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } 

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        // 添加选择状态属性（如果是DTO的话）
        public bool IsSelected { get; set; }
    }
}
