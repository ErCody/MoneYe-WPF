using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Messages;
using MoneYe_WPF.Model;
using MoneYe_WPF.Services;

namespace MoneYe_WPF.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public INavigationService NavigationService;
        public IMessenger Messenger;
        public IErrorLogger Logger;
        public IValidator Validator;

        public LoginViewModel(INavigationService navigationService, 
            IMessenger messenger,
            IErrorLogger logger, 
            IValidator validator)
        {
            NavigationService = navigationService;
            Messenger = messenger;
            Logger = logger;
            Validator = validator;
        }

        private RelayCommand _regCommand;

        public RelayCommand RegCommand => _regCommand ??= new RelayCommand(
                () =>
                {
                    NavigationService.NavigateTo<RegViewModel>();
                });

        private RelayCommand<User> _loginCommand;

        public RelayCommand<User> LoginCommand => _loginCommand ??= new RelayCommand<User>(
            param =>
            {
                try
                {
                    var userEmail = Validator.GetEmail(Email);
                    var user = UserStorage.Instance.GetUserByLoginInfo(userEmail, Password);
                    Messenger.Send(new UserMessage()
                    {
                        User = user
                    });
                    NavigationService.NavigateTo<MainScreenViewModel>();
                }
                catch
                {
                    MessageBox.Show("Try Again");
                }
            });
    }
}
