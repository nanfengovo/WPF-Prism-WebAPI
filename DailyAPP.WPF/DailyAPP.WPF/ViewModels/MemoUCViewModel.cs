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
    class MemoUCViewModel:BindableBase
    {
        #region 备忘录数据
        /// <summary>
        /// 备忘录数据
        /// </summary>
        private List<MemorandumInfoDTO> _MemorandumInfoDTOList;

        public List<MemorandumInfoDTO> MemorandumInfoDTOList
        {
            get { return _MemorandumInfoDTOList; }
            set
            {
                _MemorandumInfoDTOList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public MemoUCViewModel()
        {
            CreateMemoList();
            ShowAddMemoCmm = new DelegateCommand(ShowAddMemo);
        }

        #region 显示备忘录
        private bool _IsShowAddMemo;

        public bool IsShowAddMemo
        {
            get { return _IsShowAddMemo; }
            set
            {
                _IsShowAddMemo = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 添加备忘录事项
        /// </summary>
        private void ShowAddMemo()
        {
            IsShowAddMemo = true;
        }

        //显示添加备忘录命令
        public DelegateCommand ShowAddMemoCmm { get; set; }
        #endregion


        #region 模拟备忘录数据
        /// <summary>
        /// 创建备忘录数据
        /// </summary>
        private void CreateMemoList()
        {
            MemorandumInfoDTOList = new List<MemorandumInfoDTO>();
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "测试录屏", Content = "仔细给客户演示测试" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
            MemorandumInfoDTOList.Add(new MemorandumInfoDTO() { Title = "上传录屏", Content = "上传录屏时，仔细检查是否有录屏效果" });
        }
        #endregion
    }
}
