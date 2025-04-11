using DailyAPP.WPF.HttpClients;
using DailyAPP.WPF.ViewModels;
using DailyAPP.WPF.Views;
using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DailyAPP.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 设置启动页
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWin>();
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //登录
            containerRegistry.RegisterDialog<LoginUC, LoginUCViewModel>();

            //请求
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));

            //导航页
            //首页
            containerRegistry.RegisterForNavigation<HomeUC, HomeUCViewModel>();
            //待办事项
            containerRegistry.RegisterForNavigation<WaitUC, WaitUCViewModel>();
            //备忘录
            containerRegistry.RegisterForNavigation<MemoUC, MemoUCViewModel>();
            //设置页
            containerRegistry.RegisterForNavigation<SettingUC, SettingUCViewModel>();

            //设置页左侧导航
            //个性化
            containerRegistry.RegisterForNavigation<PersonalUC, PersonalUCViewModel>();
            //关于更多
            containerRegistry.RegisterForNavigation<AboutUsUC>();
            //系统设置
            containerRegistry.RegisterForNavigation<SysSetUC>();

        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginUC", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }
                //主界面的上下文
                var mainVM = App.Current.MainWindow.DataContext as MainWinViewModel;
                if (mainVM != null)
                {
                    if (callback.Parameters.ContainsKey("LoginName"))
                    {
                        string name = callback.Parameters.GetValue<string>("LoginName");
                        mainVM.SwtDefault(name);
                    }

                }

                base.OnInitialized();
            });
        }
    }

}
