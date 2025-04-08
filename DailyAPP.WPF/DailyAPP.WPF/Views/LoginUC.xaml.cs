using DailyAPP.WPF.MsgEvents;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DailyAPP.WPF.Views
{
    /// <summary>
    /// LoginUC.xaml 的交互逻辑
    /// </summary>
    public partial class LoginUC : UserControl
    {
        //发布订阅
        private readonly IEventAggregator Aggregator;
        public LoginUC(IEventAggregator _Aggregator)
        {
            InitializeComponent();

            Aggregator = _Aggregator;
            
            Aggregator.GetEvent<MsgEvent>().Subscribe(Sub);
        }

        /// <summary>
        /// 执行的业务
        /// </summary>
        /// <param name="obj"></param>
        private void Sub(string obj)
        {
            RegLoginBar.MessageQueue?.Enqueue(obj);
        }
    }
}
