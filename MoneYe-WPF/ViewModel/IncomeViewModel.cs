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
    public class IncomeViewModel:ViewModelBase
    {
        public string Amount { get; set; }
        public Money Money { get; set; }
        public INavigationService NavigationService;
        public IMessenger Messenger;
        public MoneyService MoneyService;

        public IncomeViewModel(INavigationService navigationService, IMessenger messenger)
        {
            NavigationService = navigationService;
            Messenger = messenger;
            Messenger.Register<MoneyMessage>(this, message =>
            {
                Money = message.Money;
            });
        }

        private RelayCommand<Money> _returnCommand;

        public RelayCommand<Money> ReturnCommand => _returnCommand = new RelayCommand<Money>(
            param =>
            {
                MoneyService.Add(Money, decimal.Parse(Amount));
                NavigationService.NavigateTo<MainScreenViewModel>();
                Messenger.Send(new MoneyMessage()
                {
                    Money = Money
                });
            });
    }
}
