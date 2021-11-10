using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Messages;
using MoneYe_WPF.Model;
using MoneYe_WPF.Services;

namespace MoneYe_WPF.ViewModel
{
    class Balance_ViewModel : ViewModelBase
    {
        public IMessenger Messenger;
        public INavigationService NavigationService;
        public User User { get; set; }
        public Balance_ViewModel(IMessenger messenger, INavigationService navigation)
        {
            NavigationService = navigation;
            Messenger = messenger;

            Messenger.Register<UserNullMoneyMessage>(this, message =>
            {
                User = message.User;
            });
           
        }

        public Money Result { get; set; }
        public string Amount { get; set; }
        public Currency Currency { get; set; }

        private RelayCommand _regCommand;

        public RelayCommand RegCommand => _regCommand ??= new RelayCommand(
            () =>
            {
                if (Currency != Currency.None)
                {
                    User.Balance = new Money()
                    {
                        Amount = decimal.Parse(Amount),
                        Currency = Currency
                    };
                    Messenger.Send(new UserMessage()
                    {
                        User = User
                    });
                    UserStorage.Instance.AddUser(User);
                    NavigationService.NavigateTo<MainScreenViewModel>();
                }
            });
    }
}
