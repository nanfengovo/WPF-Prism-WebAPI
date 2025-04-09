using DailyAPP.WPF.DTOs;
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
            //创建统计面板数据
            CreateStatPanelList();
            //创建待办事项数据
            CreateWaitList();
            //创建备忘录数据
            CreateMemorandumList();
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


        #region 待办事项数据
        /// <summary>
        /// 待办事项数据
        /// </summary>
        private List<WaitInfoDTO> _WaitlList;

        public List<WaitInfoDTO> WaitlList
        {
            get { return _WaitlList; }
            set
            {
                _WaitlList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region 备忘录数据
        /// <summary>
        /// 备忘录数据
        /// </summary>
        private List<MemorandumInfoDTO> _MemorandumList;

        public List<MemorandumInfoDTO> MemorandumList
        {
            get { return _MemorandumList; }
            set 
            {
                _MemorandumList = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 模拟统计面板数据
        /// <summary>
        /// 创建统计面板数据
        /// </summary>

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
        #endregion

        #region 模拟待办事项数据
        /// <summary>
        /// 创建待办事项数据
        /// </summary>
        private void CreateWaitList()
        {
            WaitlList = new List<WaitInfoDTO>();
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏",Content = "仔细给客户演示测试"});
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏",Content = "上传录屏时，仔细检查是否有录屏效果"});
        }
        #endregion

        #region 模拟备忘录数据
        /// <summary>
        /// 创建备忘录数据
        /// </summary>
        private void CreateMemorandumList()
        {
            MemorandumList = new List<MemorandumInfoDTO>();
            MemorandumList.Add(new MemorandumInfoDTO() { Title = "备忘录1", Content = "仔细给客户演示测试" });
            MemorandumList.Add(new MemorandumInfoDTO() { Title = "备忘录2", Content = "上传录屏时，仔细检查是否有录屏效果" });
        }
        #endregion
    }
}
