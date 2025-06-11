using DailyAPP.WPF.EntityFrameCore.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.EntityFrameCore.Config
{
    public class MyDbContext:DbContext
    {
        // 实体集合定义
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region 数据库使用SqlServer 需要搭配EntityFrameworkCore.SqlServer
            //string conStr = "Server = . ;Database = DailyAppWPF;Trusted_Connection = true";
            //optionsBuilder.UseSqlServer(conStr);
            #endregion

            #region 数据库使用SQLite 需要搭配EntityFrameworkCore.Sqlite
            //相对路径 无效
            optionsBuilder.UseSqlite("Data Source=DailyAppWPF.db");
            //绝对路径 可以
            //optionsBuilder.UseSqlite("Data Source=E:\\Code\\项目--学习\\WPF(Prism)+WebAPI\\DailyAPP.WPF - 独立运行版本\\DailyAPP.WPF\\DailyAppWPF.db");
            #endregion

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置User-Role多对多关系
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => ur.Id); // 主键[7](@ref)

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId); // 外键到User[2,6](@ref)

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId); // 外键到Role[2,6](@ref)

            // 配置Role-Menu多对多关系 (修正RoleMenu实体)
            modelBuilder.Entity<RoleMenu>()
                .HasKey(rm => rm.Id); // 主键[7](@ref)

            // 修正外键：RoleMenu应关联Role和Menu
            modelBuilder.Entity<RoleMenu>()
                .HasOne(rm => rm.Role)
                .WithMany(r => r.RoleMenus)
                .HasForeignKey(rm => rm.RoleId); // 外键到Role[6](@ref)




        }
    }
}
