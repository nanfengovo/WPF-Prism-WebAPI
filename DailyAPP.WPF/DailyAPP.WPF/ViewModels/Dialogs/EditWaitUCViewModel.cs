using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.Service;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DailyAPP.WPF.ViewModels.Dialogs
{
    /// <summary>
    /// 编辑待办事项的视图模型
    /// </summary>
    class EditWaitUCViewModel : BindableBase, IDialogHostAware
    {
        //对话框主机唯一标识
        private const string DailogHostName = "RootDialog";

        /// <summary>
        /// 待办事项的信息
        /// </summary>
        public WaitInfoDTO WaitInfoDTO { get; set; } = new WaitInfoDTO();

        public EditWaitUCViewModel()
        {
            //确定
            SaveCommand = new DelegateCommand(Save);
            //取消
            CancelCommand = new DelegateCommand(Cancel);
        }

        /// <summary>
        /// 确定的命令
        /// </summary>
        public DelegateCommand SaveCommand { get; set; }
        /// <summary>
        /// 取消命令
        /// </summary>
        public DelegateCommand CancelCommand { get; set; }

        /// <summary>
        /// 打开过程中执行(接收数据)
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpening(IDialogParameters parameters)
        {
            WaitInfoDTO = parameters.GetValue<WaitInfoDTO>("OldWaitInfoDTO");
        }

        /// <summary>
        /// 确定
        /// </summary>
        private void Save()
        {
            if (String.IsNullOrEmpty(WaitInfoDTO.Title) || string.IsNullOrEmpty(WaitInfoDTO.Content))
            {
                MessageBox.Show("待办信息不全");
                return;
            }

            if (DialogHost.IsDialogOpen(DailogHostName))
            {
                DialogParameters paras = new DialogParameters();
                paras.Add("WaitInfoDTO", WaitInfoDTO);
                DialogHost.Close(DailogHostName, new DialogResult(ButtonResult.OK, paras));
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DailogHostName))
            {
                DialogHost.Close(DailogHostName, new DialogResult(ButtonResult.No));
            }
        }
    }
}
