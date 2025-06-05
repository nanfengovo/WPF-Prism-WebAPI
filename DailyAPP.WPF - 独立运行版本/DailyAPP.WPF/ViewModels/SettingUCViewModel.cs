using DailyAPP.WPF.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.ViewModels
{
    class SettingUCViewModel:BindableBase
    {

        public SettingUCViewModel(IRegionManager _regionManager)
        {
            RegionManager = _regionManager;
            CreateMenu();
            NavigateCmm = new DelegateCommand<LeftMenuInfo>(Navigate);
        }

        #region 区域导航
        private readonly IRegionManager RegionManager;

        public DelegateCommand<LeftMenuInfo> NavigateCmm { get; set; }

        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="menu"></param>
        private void Navigate(LeftMenuInfo menu)
        {
            if(menu ==null || string.IsNullOrEmpty(menu.ViewName))
            {
                return;
            }

            //导航
            RegionManager.Regions["SettingRegion"].RequestNavigate(menu.ViewName);
        }
        #endregion


        #region 左侧菜单 
        private List<LeftMenuInfo> _LeftMenulist;

        /// <summary>
        /// 左侧菜单
        /// </summary>
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


        #region 创建菜单数据
        /// <summary>
        /// 创建菜单数据
        /// </summary>
        public void CreateMenu()
        {
            LeftMenulist = new List<LeftMenuInfo>();
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "Palette", MenuName = "个性化", ViewName = "PersonalUC" });
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "Cog", MenuName = "系统设置", ViewName = "SysSetUC" });
            LeftMenulist.Add(new LeftMenuInfo() { Icon = "Information", MenuName = "关于更多", ViewName = "AboutUsUC" });
        }
        #endregion






    }
}
