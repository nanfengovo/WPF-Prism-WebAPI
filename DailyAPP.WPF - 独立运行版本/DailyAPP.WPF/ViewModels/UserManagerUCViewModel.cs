using DailyAPP.WPF.Domain.IServe;
using DailyAPP.WPF.DTOs;
using DailyAPP.WPF.EntityFrameCore.EntityModel;
using Prism.Commands;
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
            ShowAddUserCmm = new DelegateCommand(ShowAddUser);
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


        #region 显示添加用户
        private bool _IsShowAddUser;

        public bool IsShowAddUser
        {
            get { return _IsShowAddUser; }
            set
            {
                _IsShowAddUser = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 添加备忘录事项
        /// </summary>
        private void ShowAddUser()
        {
            IsShowAddUser = true;
        }

        //显示添加备忘录命令
        public DelegateCommand ShowAddUserCmm { get; set; }
        #endregion
    }
}
