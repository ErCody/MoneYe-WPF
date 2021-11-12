using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
            Messenger.Register<MoneyMessage>(this, message =>
            {
                ActiveUser.Balance = message.Money;
                var user = UserStorage.Instance.GetUserByLoginInfo(ActiveUser.Email, ActiveUser.Password);
                UserStorage.Instance.EditUser(user, ActiveUser);
            });

        }
        private RelayCommand<Money> _consumptionCommand;
        public RelayCommand<Money> ConsumptionCommand => _consumptionCommand ??= new RelayCommand<Money>(
            param =>
            {
                NavigationService.NavigateTo<ConsumptiomModelView>();
                Messenger.Send(new MoneyMessage()
                {
                    Money = ActiveUser.Balance
                });
            });

        private RelayCommand<Money> _incomeCommand;
        public RelayCommand<Money> IncomeCommand => _incomeCommand ??= new RelayCommand<Money>(
            param =>
            {
                NavigationService.NavigateTo<IncomeViewModel>();
                Messenger.Send(new MoneyMessage()
                {
                    Money = ActiveUser.Balance
                });

            });
    }
}