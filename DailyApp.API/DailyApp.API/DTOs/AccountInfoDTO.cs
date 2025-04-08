namespace DailyApp.API.DTOs
{
    /// <summary>
    /// 登录账号的数据传输对象(用来接收注册的信息)
    /// </summary>
    public class AccountInfoDTO
    {
        /// <summary>
        /// 账号名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
    }
}
