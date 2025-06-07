using DailyAPP.WPF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.Domain.IServe
{
    public interface IUserManagerServe
    {
        Task<bool> AddUserAsync(AccountInfoDTO account);
    }
}
