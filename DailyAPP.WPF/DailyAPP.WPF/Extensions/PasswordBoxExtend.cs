using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DailyAPP.WPF.Extensions
{
    /// <summary>
    /// PasswordBox的扩展属性
    /// </summary>
    public class PasswordBoxExtend
    {
        public static string GetPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(PwdProperty);
        }

        public static void SetPwd(DependencyObject obj, string value)
        {
            obj.SetValue(PwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdProperty =
            DependencyProperty.RegisterAttached("Pwd", typeof(string), typeof(PasswordBoxExtend), new PropertyMetadata("",OnPwdChanged));

        /// <summary>
        /// 自定义的附加属性发生变化，通知Password属性
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnPwdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            string newpwd = (string)e.NewValue;//新值
            if (passwordBox != null && passwordBox.Password != newpwd)
            {
                passwordBox.Password = newpwd;
            }
        }
    }


    /// <summary>
    /// Password变化，自定义的要跟着变化
    /// </summary>
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        /// <summary>
        /// 附加 注入事件
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += OnPasswordChanged;
        }

        /// <summary>
        /// Password变化，自定义的要跟着变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string pwd = PasswordBoxExtend.GetPwd(passwordBox);
            if(passwordBox != null && pwd != passwordBox.Password)
            {
                PasswordBoxExtend.SetPwd(passwordBox, passwordBox.Password);
            }
        }

        /// <summary>
        /// 销毁 移除事件
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnPasswordChanged;
        }
    }

}
