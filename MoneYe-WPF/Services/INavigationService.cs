using GalaSoft.MvvmLight;

namespace MoneYe_WPF.Services
{
    public interface INavigationService
    {
        public void NavigateTo<T>() where T : ViewModelBase;
    }
}