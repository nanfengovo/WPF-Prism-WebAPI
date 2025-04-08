namespace DailyApp.API.ApiReponses
{
    /// <summary>
    /// 响应模型
    /// </summary>
    public class ApiReponse
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        public object ResultData { get; set; }
    }
}
