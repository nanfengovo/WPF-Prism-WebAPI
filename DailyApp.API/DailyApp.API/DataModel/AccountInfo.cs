using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyApp.API.DataModel
{
    /// <summary>
    /// 登录账号的数据模型
    /// </summary>
    [Table("T_AccountInfos")]
    public class AccountInfo
    {
        /// <summary>
        /// 账号ID
        /// </summary>
        [Key]//主键 自增
        public int AccountId { get; set; }

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
