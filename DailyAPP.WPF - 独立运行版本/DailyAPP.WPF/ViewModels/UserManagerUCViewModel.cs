using DailyAPP.WPF.Domain.IServe;
using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.EntityFrameCore.EntityModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.ViewModels
{
    internal class UserManagerUCViewModel: BindableBase
    {
        public readonly IUserManagerServe _userManagerServe;

        public UserManagerUCViewModel(IUserManagerServe userManagerServe)
        {
            _userManagerServe = userManagerServe;

            GetUserList();
        }

        #region 查找用户
        private string _searchText;

        /// <summary>
        /// 查找用户
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region 用户数据
        /// <summary>
        /// 待办事项数据
        /// </summary>
        private List<UserDTO> _UserList;

        public List<UserDTO> UserList
        {
            get { return _UserList; }
            set
            {
                _UserList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// 获取用户列表
        /// </summary>
        public void GetUserList()
        {
            UserList = _userManagerServe.GetAllUser();
        }
    }
}
