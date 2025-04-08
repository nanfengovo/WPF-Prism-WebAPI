using DailyAPP.WPF.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.ViewModels
{
    class HomeUCViewModel:BindableBase
    {

        public HomeUCViewModel()
        {
            CreateStatPanelList();
        }
        #region 统计面板数据
        /// <summary>
        /// 统计面板数据
        /// </summary>
        private List<StatPanelInfo> _StatPanelList;

        public List<StatPanelInfo> StatPanelList
        {
            get { return _StatPanelList; }
            set
            {
                _StatPanelList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        private void CreateStatPanelList()
        {
            StatPanelList = new List<StatPanelInfo>();
            StatPanelList.Add(new StatPanelInfo()
            {
                Icon = "ClockFast",
                ItemName = "汇总",
                Result = "9",
                BackColor = "#FF0CA0FF",
                ViewName = "WaitUC"
            });
            StatPanelList.Add(new StatPanelInfo()
            {
                Icon = "ClockCheckOutline",
                ItemName = "已完成",
                Result = "9",
                BackColor = "#FF1ECA3A",
                ViewName = "WaitUC"
            });
            StatPanelList.Add(new StatPanelInfo()
            {
                Icon = "ChartLineVariant",
                ItemName = "完成比例",
                Result = "90%",
                BackColor = "#FF02C6DC",
                ViewName = "WaitUC"
            });
            StatPanelList.Add(new StatPanelInfo()
            {
                Icon = "PlaylistStar",
                ItemName = "备忘录",
                Result = "20",
                BackColor = "#FFFFA000",
                ViewName = "MemoUC"
            });

        }
    }
}
