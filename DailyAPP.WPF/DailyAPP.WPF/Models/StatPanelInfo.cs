using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.Models
{
    /// <summary>
    /// 首页统计面板信息
    /// </summary>
    class StatPanelInfo:BindableBase
    {
        /// <summary>
        /// 统计面板图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 统计面板标题
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 统计结果
        /// </summary>
        private string _Result;

        public string Result
        {
            get { return _Result; }
            set 
            {
                _Result = value;
                RaisePropertyChanged();
            }
        }



        /// <summary>
        /// 背景颜色
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// 跳转到的界面名称
        /// </summary>
        public string ViewName { get; set; }

    }
}
