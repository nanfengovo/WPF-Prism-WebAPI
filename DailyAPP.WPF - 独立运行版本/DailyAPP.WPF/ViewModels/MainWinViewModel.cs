using DailyAPP.WPF.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DailyAPP.WPF.ViewModels
{
    internal class MainWinViewModel:BindableBase
    {
        #region 左侧菜单
        private List<LeftMenuInfo> _LeftMenulist;

        public List<LeftMenuInfo> LeftMenulist
        {
            get { return _LeftMenulist; }
            set 
            {
                _LeftMenulist = value; 
                RaisePropertyChanged();
            }
        }
        #endregion
       
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWinViewModel(IRegionManager _regionManager)
        {
            LeftMenulist = new List<LeftMenuInfo>();
            CreateMenu();
            //区域
            regionManager = _regionManager;

            //导航命令
            NavigateCmm = new DelegateCommand<LeftMenuInfo>(Navigate);

            //后退
            GoBackCmm = new DelegateCommand(GoBack);

            //前进
            GoForwardCmm = new DelegateCommand(GoForward);

            

        }
        #region 区域和导航实现导航
        private readonly IRegionManager regionManager;

        public DelegateCommand<LeftMenuInfo> NavigateCmm { get; set; } //导航命令

        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="menu"></param>
        private void Navigate(LeftMenuInfo menu)
        {
            if(menu == null && string.IsNullOrEmpty(menu?.ViewName))
            {
                return;
            }

            //导航 区域
            regionManager.Regions["MainViewRegion"].RequestNavigate(menu.ViewName,callback =>
            {
                journal = callback.Context.NavigationService.Journal;//获取导航历史记录
            });

        }
        #endregion
        /// <summary>
        /// 创建菜单数据
        /// </summary>
        public void CreateMenu()
        {
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "Home", MenuName = "首页", ViewName = "HomeUC" });
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "NotebookOutline", MenuName = "待办事项", ViewName = "WaitUC" });
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "NotebookPlus", MenuName = "备忘录", ViewName = "MemoUC" });
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "UserGroup", MenuName = "用户管理", ViewName = "UserManagerUC" });
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "UserBoxes", MenuName = "用户管理", ViewName = "UserManagerUC" });
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "Cog", MenuName = "设置", ViewName = "SettingUC" });
        }

        #region 前进 后退
        //历史记录
        private IRegionNavigationJournal journal;

        public DelegateCommand GoBackCmm { get; private set; }//后退

        public DelegateCommand GoForwardCmm { get; private set; }//前进

        private void GoBack()
        {
            if (journal != null && journal.CanGoBack)
            {
                journal.GoBack();
            }
        }

        private void GoForward()
        {
            if (journal != null && journal.CanGoForward)
            {
                journal.GoForward();
            }
        }
        #endregion

        #region 设置默认是首页
        /// <summary>
        /// 设置默认是首页
        /// </summary>
        public void SwtDefault(string loginName)
        {
            NavigationParameters paras = new NavigationParameters();
            paras.Add("loginName", loginName);
            //导航 区域
            regionManager.Regions["MainViewRegion"].RequestNavigate("HomeUC", callback =>
            {
                journal = callback.Context.NavigationService.Journal;//获取导航历史记录
            },paras);
        }
        #endregion


    }
}
