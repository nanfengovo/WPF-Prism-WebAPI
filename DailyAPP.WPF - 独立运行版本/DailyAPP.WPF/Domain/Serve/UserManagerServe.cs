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

        public Task<bool> AddUserAsync(AccountInfoDTO account)
        {
            try
            {
                // 1、先效验是否存在账号
                var ExistUser = _dbContext.Users.FirstOrDefault(user => user.UserName == account.Account);

                if (ExistUser != null)
                {
                    // 如果用户已存在，返回 false
                    return Task.FromResult(false);
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
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return Task.FromResult(false);
            }
        }
    }
}
