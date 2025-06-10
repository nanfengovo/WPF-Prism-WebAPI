using DailyAPP.WPF.Domain.IServe;
using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.EntityFrameCore.Config;
using DailyAPP.WPF.EntityFrameCore.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.Domain.Serve
{
    public class RoleManageServe : IRoleManageServe
    {
        public readonly MyDbContext _dbcontext;

        public RoleManageServe(MyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<(bool Success, string Msg)> AddRoleAsync(AddRoleDTO role)
        {
            //1、新添加的角色名是否存在
            var Existrole = await _dbcontext.Roles.FirstOrDefaultAsync(x => x.RoleName == role.RoleName);
            if(role != null)
            {
                return (false, "角色名已存在，请重新输入");
            }
            //2、添加角色
            else
            {
                var newRole = new Role
                {
                    RoleName = role.RoleName,
                    RoleCode = role.RoleCode,
                    CreateTime = DateTime.Now,
                    LastModifiedTime = DateTime.Now
                };
                _dbcontext.Roles.Add(newRole);
                await _dbcontext.SaveChangesAsync();
                return (true, "添加角色成功");
            }
        }
    }
}
