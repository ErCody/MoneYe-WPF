using System;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Model;
using MoneYe_WPF.Services;

namespace MoneYe_WPF.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        public INavigationService NavigationService;
        public IMessenger Messenger;
        public IErrorLogger Logger;

        public LoginViewModel(INavigationService navigationService, IMessenger messenger, IErrorLogger logger)
        {
            NavigationService = navigationService;
            Messenger = messenger;
            Logger = logger;
        }

        private RelayCommand _regCommand;

        public RelayCommand RegCommand => _regCommand ??= new RelayCommand(
                () =>
                {
                    try
                    {
                        
                        NavigationService.NavigateTo<RegViewModel>();
                    }
                    catch (Exception e)
                    {
                        Logger.LogError("Unhandled error on RegCommand", e);
                    }
                }
            );
    }
}
