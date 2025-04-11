namespace DailyApp.API.DTOs
{
    /// <summary>
    /// 统计待办事项的DTO
    /// </summary>
    public class StatWaitDTO
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
        public string FinishPercent
        {
            get
            {
                if (TotalCount == 0)
                {
                    //总数（分母为0的特殊情况）
                    return "0.00%";
                }
                return (FinnishCount * 100.00 / TotalCount).ToString("f2") + "%";
            }
        }
    }
}
