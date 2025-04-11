using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.DTOs
{
    /// <summary>
    /// 接收API待办事项统计的DTO
    /// </summary>
    internal class StatWaitDTO
    {
        /// <summary>
        /// 待办事项的总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 已完成事项的数量
        /// </summary>
        public int FinnishCount { get; set; }


        /// <summary>
        /// 完成百分比
        /// </summary>
        public string FinishPercent { get; set; }

    }
}
