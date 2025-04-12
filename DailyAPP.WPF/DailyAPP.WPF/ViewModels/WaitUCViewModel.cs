using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.HttpClients;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DailyAPP.WPF.ViewModels
{
    /// <summary>
    /// 待办事项的视图模型
    /// </summary>
    class WaitUCViewModel :BindableBase
    {

        //请求api的客户端
        private readonly HttpRestClient HttpClient;

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
        public WaitUCViewModel(HttpRestClient _HttpClient)
        {
           

            //查询待办命令
            QueryWaitListCmm = new DelegateCommand(QueryWaitList);

            //显示添加待办
            ShowAddWaitCmm = new DelegateCommand(ShowAddWait);
            HttpClient = _HttpClient;

            QueryWaitList();
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


        #region 查询待办事项数据

        //查询条件是标题
        public string SearchTitle { get; set; }

        //查询条件是索引
        public int SearchWaitIndex { get; set; }


        public DelegateCommand QueryWaitListCmm { get; set; }

        /// <summary>
        /// 查询待办事项数据
        /// </summary>
        private void QueryWaitList()
        {
            //WaitlList = new List<WaitInfoDTO>();

            int? Status = null;
            if(SearchWaitIndex == 1)
            {
                Status = 0;
            }
            else if (SearchWaitIndex == 2)
            {
                Status = 1;
            }
            //调用api实现查询
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = RestSharp.Method.GET;
            apiRequest.Route = $"Wait/QueryWait?Title={SearchTitle}&Status={Status}";
            
            ApiReponse reponse = HttpClient.Execute(apiRequest);
            //成功
            if (reponse.ResultCode == 1)
            {
               
                WaitlList = JsonConvert.DeserializeObject<List<WaitInfoDTO>>(reponse.ResultData.ToString());

            }
            else
            {
                WaitlList = new List<WaitInfoDTO>();
            }


        }
        #endregion
    }
}
