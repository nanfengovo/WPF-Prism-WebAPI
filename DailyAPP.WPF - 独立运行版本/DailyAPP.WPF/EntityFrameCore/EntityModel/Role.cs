
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.EntityFrameCore.EntityModel
{
    /// <summary>
    /// 角色对象
    /// </summary>
    [Table("T_Role")]
    public class Role : CommonAttributes
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string? RoleName { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string? RoleCode { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>(); // 通过关联表导航
        public List<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
    }
}
