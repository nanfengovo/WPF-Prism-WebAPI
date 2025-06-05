using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.EntityFrameCore.EntityModel
{
    // 角色-菜单关联表
    [Table("T_Role_Menu")]
    public class RoleMenu
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; } // 修正后 ✅

        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        public Menu Menu { get; set; } // 新增导航属性 ✅
    }
}
