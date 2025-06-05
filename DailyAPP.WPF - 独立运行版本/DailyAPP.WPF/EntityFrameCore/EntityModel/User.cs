
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.EntityFrameCore.EntityModel
{
    /// <summary>
    /// 登录用户对象
    /// </summary>
    [Table("T_User")]
    public class User : CommonAttributes
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("PasswordHash")]
        [Required]
        public string PasswordHash { get; set; } // 明确存储加密值

        /// <summary>
        /// 角色列表
        /// </summary>
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>(); // 通过关联表导航


    }
}
