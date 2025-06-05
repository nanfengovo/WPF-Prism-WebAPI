using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.EntityFrameCore.EntityModel
{
    [Table("T_Menu")]
    public class Menu:CommonAttributes
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuNo { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? Icon { get; set; }

        public int? ParentId { get; set; } // 增加父菜单ID

        public int Order { get; set; } // 排序字段
    }
}
