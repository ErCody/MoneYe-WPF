using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Services;

namespace MoneYe_WPF.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        public INavigationService NavigationService;
        public IMessenger Messenger;

        public LoginViewModel(INavigationService navigationService, IMessenger messenger)
        {
            NavigationService = navigationService;
            Messenger = messenger;
        }
    }
}
