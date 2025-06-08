using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.Domain.IServe
{
    public interface IMenuManageServe
    {
        Task<bool> AddMenu(string menuName, string viewName);
    }
}
