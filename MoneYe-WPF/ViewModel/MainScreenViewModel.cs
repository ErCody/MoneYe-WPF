using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Messages;
using MoneYe_WPF.Model;
using MoneYe_WPF.Services;

namespace MoneYe_WPF.ViewModel
{
    public class MainScreenViewModel: ViewModelBase
    {
        public IMessenger Messenger;
        public INavigationService NavigationService;
        public IErrorLogger ErrorLogger;
        public User ActiveUser { get; set; } = new User();

        public MainScreenViewModel(IMessenger messenger, INavigationService navigationService, IErrorLogger errorLogger)
        {
            Messenger = messenger;
            NavigationService = navigationService;
            ErrorLogger = errorLogger;

            Messenger.Register<UserMessage>(this, message => { ActiveUser = message.User; });
            
        }
    }
}