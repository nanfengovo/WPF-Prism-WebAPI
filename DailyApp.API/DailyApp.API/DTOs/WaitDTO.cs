namespace DailyApp.API.DTOs
{
    /// <summary>
    /// 待办事项的DTO(接收添加待办事项的数据)
    /// </summary>
    public class WaitDTO
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
