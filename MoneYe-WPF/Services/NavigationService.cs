using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Messages;

namespace MoneYe_WPF.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IMessenger _message;

        public NavigationService(IMessenger message)
        {
            _message = message;
        }


        public void NavigateTo<T>() where T : ViewModelBase
        {
            _message.Send(new NavigationMessage
            {
                ViewModelType = typeof(T)
            });
        }
    }
}