using DailyAPP.WPF.DTOs;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.ViewModels
{
    /// <summary>
    /// 待办事项的视图模型
    /// </summary>
    class WaitUCViewModel :BindableBase
    {
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

        /// <summary>
        /// 构造函数
        /// </summary>
        public WaitUCViewModel()
        {
            CreateWaitList();

            //显示添加待办
            ShowAddWaitCmm = new DelegateCommand(ShowAddWait);
        }

        #region 显示添加待办
        private bool _IsShowAddWait;

        public bool IsShowAddWait
        {
            get { return _IsShowAddWait; }
            set 
            {
                _IsShowAddWait = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 添加待办事项
        /// </summary>
        private void ShowAddWait()
        {
            IsShowAddWait = true;
        }

        //显示添加待办命令
        public DelegateCommand ShowAddWaitCmm { get; set; }  
        #endregion


        #region 模拟待办事项数据
        /// <summary>
        /// 创建待办事项数据
        /// </summary>
        private void CreateWaitList()
        {
            WaitlList = new List<WaitInfoDTO>();
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
        }
        #endregion
    }
}
