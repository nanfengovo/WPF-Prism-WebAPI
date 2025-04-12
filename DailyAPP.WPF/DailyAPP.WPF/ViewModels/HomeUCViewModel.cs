using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.HttpClients;
using DailyAPP.WPF.Models;
using DailyAPP.WPF.Service;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DailyAPP.WPF.ViewModels
{
    class HomeUCViewModel:BindableBase,INavigationAware
    {
        //请求api的客户端
        private readonly HttpRestClient HttpClient;

        //对话服务
        //private readonly IDialogService DialogService;

        //自定义的对话服务
        private readonly DialogHostService DialogHostService;

        public HomeUCViewModel(HttpRestClient _HttpClient, DialogHostService _DialogHostService)
        {
            HttpClient = _HttpClient;
            DialogHostService = _DialogHostService;
            //DialogService = _DialogService;
            //创建统计面板数据
            CreateStatPanelList();
            //获取待办状态的待办事项的数据
            GetWaitingList();
            //创建备忘录数据
            CreateMemorandumList();

            //打开待办事项的命令
            ShowAddWaitDialogCmm = new DelegateCommand(ShowAddWaitDialog);



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

        #region 获取待办状态的待办事项的数据
        /// <summary>
        /// 获取待办状态的待办事项的数据
        /// </summary>
        private void GetWaitingList()
        {
            WaitlList = new List<WaitInfoDTO>();
            //WaitlList.Add(new WaitInfoDTO() { Title = "测试录屏",Content = "仔细给客户演示测试"});
            //WaitlList.Add(new WaitInfoDTO() { Title = "上传录屏",Content = "上传录屏时，仔细检查是否有录屏效果"});
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = RestSharp.Method.GET;
            apiRequest.Route = "Wait/GetWaiting";

            var response = HttpClient.Execute(apiRequest);

            if (response.ResultCode == 1)
            {
                //将请求返回的JSON数据反序列化成对象
                WaitlList = JsonConvert.DeserializeObject<List<WaitInfoDTO>>(response.ResultData.ToString());
                RefreshWaitStat();
            }
            
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


        //public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        //{
        //    throw new NotImplementedException();
        //}

        #region 显示登录用户信息
        private string _LoginInfo;

        public string LoginInfo
        {
            get { return _LoginInfo; }
            set 
            { 
                _LoginInfo = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// 接收导航并处理
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("loginName"))
            {
                DateTime now = DateTime.Now;
                string[] week = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                string loginName = navigationContext.Parameters.GetValue<string>("loginName");
                LoginInfo = $"你好！{loginName} ,今天是{now.ToString("yyyy-MM-dd")} {week[(int)now.DayOfWeek]}";

                //统计待办事项
                CallStatWait();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion

        #region 待办事项统计
        private StatWaitDTO StatWaitDTO { get; set; } = new StatWaitDTO();

        /// <summary>
        /// 调用API获取统计数据
        /// </summary>
        private void CallStatWait()
        {
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = RestSharp.Method.GET;
            apiRequest.Route = "Wait/StatWait";

            var response = HttpClient.Execute(apiRequest);

            if (response.ResultCode == 1)
            {
                //将请求返回的JSON数据反序列化成对象
                StatWaitDTO = JsonConvert.DeserializeObject<StatWaitDTO>(response.ResultData.ToString());
                RefreshWaitStat();
            }
        }

        /// <summary>
        /// 刷新统计数据
        /// </summary>
        private void RefreshWaitStat()
        {
            StatPanelList[0].Result = StatWaitDTO.TotalCount.ToString();
            StatPanelList[1].Result = StatWaitDTO.FinnishCount.ToString();
            StatPanelList[2].Result = StatWaitDTO.FinishPercent;
        }
        #endregion

        #region 添加待办事项处理

        public DelegateCommand ShowAddWaitDialogCmm { get;set; }

        /// <summary>
        /// 打开添加待办事项的对话框
        /// </summary>
        private async void ShowAddWaitDialog()
        {
            var result = await DialogHostService.ShowDialog("AddWaitUC",null);
            
            if(result.Result == ButtonResult.OK)
            {
                //接收数据
                if(result.Parameters.ContainsKey("WaitInfoDTO"))
                {
                    var addMoel = result.Parameters.GetValue<WaitInfoDTO>("WaitInfoDTO");

                    //调用api实现添加事项
                    ApiRequest apiRequest = new ApiRequest();
                    apiRequest.Method = RestSharp.Method.POST;
                    apiRequest.Route = "Wait/AddWait";
                    apiRequest.Parameters = addMoel;
                    ApiReponse reponse = HttpClient.Execute(apiRequest);
                    //成功
                    if (reponse.ResultCode == 1)
                    {
                        MessageBox.Show(reponse.Msg);
                        //刷新统计数据
                        CallStatWait();
                        
                    }
                    else
                    {
                        MessageBox.Show(reponse.Msg);
                    }
                }
                
            }
        }

        #endregion


    }
}
