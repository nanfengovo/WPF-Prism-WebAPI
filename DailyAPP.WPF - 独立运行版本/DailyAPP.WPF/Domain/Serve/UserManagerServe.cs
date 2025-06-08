using DailyAPP.WPF.Domain.IServe;
using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.EntityFrameCore.Config;
using DailyAPP.WPF.EntityFrameCore.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.Domain.Serve
{
    public class UserManagerServe : IUserManagerServe
    {

        public readonly MyDbContext _dbContext;

        public UserManagerServe(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<(bool, string)> AddUserAsync(AccountInfoDTO account)
        {
            try
            {
                // 1、先效验是否存在账号
                var ExistUser = _dbContext.Users.FirstOrDefault(user => user.UserName == account.Account);

                if (ExistUser != null)
                {
                    // 如果用户已存在，返回 false
                    return Task.FromResult((false, "该用户已存在！"));
                }

                var user = new User()
                {
                    UserName = account.Account,
                    PasswordHash = account.Pwd,
                    CreateTime = DateTime.Now,
                    LastModifiedTime = DateTime.Now,
                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return Task.FromResult((true, "用户添加成功！"));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return Task.FromResult((false, "发生错误：" + ex.Message));
            }
        }

        public Task<(bool, string)> LoginAsync(string Account, string Pwd)
        {
            try
            {
                // 1、先效验是否存在账号
                var ExistUser = _dbContext.Users.FirstOrDefault(user => user.UserName == Account && user.PasswordHash == Pwd);
                if (ExistUser == null)
                {
                    // 如果用户不存在，返回 false
                    return Task.FromResult((false, "账号或密码错误！"));
                }
                // 登录成功，返回 true
                return Task.FromResult((true, "登录成功！"));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return Task.FromResult((false, "发生错误：" + ex.Message));
            }
        }
    }
}
