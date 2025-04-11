﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyApp.API.DataModel
{
    [Table("T_WaitInfos")]
    public class WaitInfo
    {
        /// <summary>
        /// 待办事项ID
        /// </summary>
        [Key]
        public int WaitId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 状态  0-待办  1 已完成
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间（默认是当前的时间）
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
