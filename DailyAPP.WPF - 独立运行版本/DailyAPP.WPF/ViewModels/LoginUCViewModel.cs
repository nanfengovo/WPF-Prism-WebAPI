using DailyAPP.WPF.Domain.IServe;
using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.HttpClients;
using DailyAPP.WPF.MsgEvents;
using DryIoc;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DailyAPP.WPF.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// 显示注册信息命令
        /// </summary>
        public DelegateCommand ShowRegInfoCmm {  get; set; }

        /// <summary>
        /// 显示登录信息命令
        /// </summary>
        public DelegateCommand ShowLogInfoCmm { get; set; }
        public string Title { get; set; } = "我的日常";

        private readonly HttpRestClient HttpClient;

        //发布订阅
        private readonly IEventAggregator Aggregator;

        private readonly IUserManagerServe _UserServe;


        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginUCViewModel(HttpRestClient _HttpClient, IEventAggregator _Aggregator, IUserManagerServe userServe)
        {
            //登录命令
            LoginCmm = new DelegateCommand(async()=> await Login());

            //显示注册内容命令
            ShowRegInfoCmm = new DelegateCommand(ShowRegInfo);

            //显示登录信息命令
            ShowLogInfoCmm = new DelegateCommand(ShowLogInfo);

            //注册命令

            // Update the DelegateCommand initialization for Regcmm to handle the async method properly.  
            Regcmm = new DelegateCommand(async () => await Reg());
            //Regcmm = new DelegateCommand(Reg);

            //实例对象
            AccountInfoDTO = new AccountInfoDTO();

            //请求Client
            HttpClient = _HttpClient;

            Aggregator = _Aggregator;

            _UserServe = userServe;
        }

        #region 注册
        public DelegateCommand Regcmm { get;set; }

        /// <summary>
        /// 注册方法
        /// </summary>
        private async Task Reg()
        {
            if (string.IsNullOrEmpty(AccountInfoDTO.Name) || string.IsNullOrEmpty(AccountInfoDTO.Account) || string.IsNullOrEmpty(AccountInfoDTO.Pwd) || string.IsNullOrEmpty(AccountInfoDTO.ConfrmPwd))
            {
                //MessageBox.Show("请填写完整信息");
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish("请填写完整信息");
                return;
            }

            if (AccountInfoDTO.Pwd != AccountInfoDTO.ConfrmPwd)
            {
                //MessageBox.Show("两次密码不一致");
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish("两次密码不一致");
                return;
            }
            //对密码加密
            AccountInfoDTO.Pwd = Md5Helper.GetMd5(AccountInfoDTO.Pwd);

            var success = await _UserServe.AddUserAsync(AccountInfoDTO);

            if(success.Item1)
            {
                //MessageBox.Show(response.Msg);
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish($"{success.Item2}");
                //清空输入框
                AccountInfoDTO.Name = "";
                AccountInfoDTO.Account = "";
                AccountInfoDTO.Pwd = "";
                AccountInfoDTO.ConfrmPwd = "";
                //注册成功切换登录
                SelectedIndex =0;
            }
            else
            {
                //MessageBox.Show(response.Msg);
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish($"{success.Item2}");
            }



        }


        #region 注册信息


        private AccountInfoDTO _AccountInfoDTO;

        public AccountInfoDTO AccountInfoDTO
        {
            get { return _AccountInfoDTO; }
            set
            {
                _AccountInfoDTO = value;
                RaisePropertyChanged();
            }
        }

        #endregion
        #endregion

        #region 显示内容的索引
        /// <summary>
        /// 显示内容的索引
        /// </summary>
        private int _SelectedIndex;

        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// 显示注册信息
        /// </summary>
        private void ShowRegInfo()
        {
            SelectedIndex = 1;
        }
        #endregion

        private void ShowLogInfo()
        {
            SelectedIndex = 0;
        }



        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand LoginCmm { get; set; }

        

        /// <summary>
        /// 登录
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private async Task Login()
        {
            // 数据的基本验证
            if (string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Pwd))
            {
                Aggregator.GetEvent<MsgEvent>().Publish("登录信息不全！");
                return;
            }

            // 对密码加密
            var encryptedPwd = Md5Helper.GetMd5(Pwd);

            // 登录异步调用
            var result = await _UserServe.LoginAsync(Account, encryptedPwd);

            if (result.Item1)
            {
                Aggregator.GetEvent<MsgEvent>().Publish(result.Item2);
                var paras = new DialogParameters { { "LoginName", Account } };
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, paras));
            }
            else
            {
                Aggregator.GetEvent<MsgEvent>().Publish(result.Item2);
            }
        }

        /// <summary>
        /// 是否可以关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void Ond(IDialogParameters parameters)
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        #region 密码
        private string _pwd;

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return _pwd; }
            set 
            {
                _pwd = value;
                
            }
        }
        #endregion

        #region 账号
        private string _Account;
        /// <summary> 
        /// 账号
        /// </summary>
        ///     
        public string Account
        {
            get { return _Account; }
            set
            {
                _Account = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        
    }
}
