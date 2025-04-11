using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DailyApp.API.DataModel
{

    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DailyDbContext : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public DailyDbContext(DbContextOptions<DailyDbContext> options):base(options)
        {

        }

        /// <summary>
        /// 账号表  virtual=--懒汉加载
        /// </summary>
        public virtual DbSet<AccountInfo> AccountInfos { get; set; }

        /// <summary>
        /// 待办事项表  virtual=--懒汉加载
        /// </summary>
        public virtual DbSet<WaitInfo> WaitInfos { get; set; }


    }
}
