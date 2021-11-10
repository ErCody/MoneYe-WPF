using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Services;
using MoneYe_WPF.View;
using MoneYe_WPF.ViewModel;
using SimpleInjector;

namespace MoneYe_WPF
{
    public partial class App : Application
    {
        public static Container Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            Start<LoginViewModel>();
            base.OnStartup(e);
        }

        private void Register()
        {
            Container = new Container();

            //Services
            Container.RegisterSingleton<IErrorLogger, ErrorLogger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IFileService, FileService>();
            Container.RegisterSingleton<IValidator, Validator>();

            //ViewModels
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegViewModel>();
            Container.RegisterSingleton<MainScreenViewModel>();
            Container.RegisterSingleton<Balance_ViewModel>();


            Container.Verify();
        }

        private void Start<T>() where T : ViewModelBase
        {
            var viewModel = Container.GetInstance<MainViewModel>();
            viewModel.CurrentViewModel = Container.GetInstance<T>();

            MainWindow window = new()
            {
                DataContext = viewModel
            };
            window.ShowDialog();
        }
    }
}