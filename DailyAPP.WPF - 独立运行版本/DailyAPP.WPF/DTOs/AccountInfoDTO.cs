using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyAPP.WPF.DTOs
{
    /// <summary>
    /// 账户DTO
    /// </summary>
    public class AccountInfoDTO:INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _account;
        public string Account
        {
            get => _account;
            set { _account = value; OnPropertyChanged(nameof(Account)); }
        }

        private string _pwd;
        public string Pwd
        {
            get => _pwd;
            set { _pwd = value; OnPropertyChanged(nameof(Pwd)); }
        }

        private string _confrmPwd;
        public string ConfrmPwd
        {
            get => _confrmPwd;
            set { _confrmPwd = value; OnPropertyChanged(nameof(ConfrmPwd)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
