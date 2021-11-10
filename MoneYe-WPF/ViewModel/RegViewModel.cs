using System;
using System.Data;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MoneYe_WPF.Messages;
using MoneYe_WPF.Model;
using MoneYe_WPF.Services;
using MoneYe_WPF.View;

namespace MoneYe_WPF.ViewModel
{
    public class RegViewModel : ViewModelBase
    {
        #region Services
        public INavigationService NavigationService;
        public IMessenger Messenger;
        public IErrorLogger Logger;
        public IValidator Validator;
        #endregion

        #region UserFields
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        #endregion


        public RegViewModel(IMessenger messenger, INavigationService navigationService, IErrorLogger logger, IValidator validator)
        {
            NavigationService = navigationService;
            Messenger = messenger;
            Logger = logger;
            Validator = validator;
        }


        private RelayCommand<User> _regCommand;

        private bool ValidatePassword()
        {
            return Password == ConfirmPassword;
        }

        private User CreateUser()
        {
            User newUser = new();
            if (!string.IsNullOrWhiteSpace(Name) &&
                !string.IsNullOrWhiteSpace(Surname) &&
                Age is not null)
            {
                newUser.FirstName = Name;
                newUser.Surname = Surname;
                newUser.Age = Age;
                newUser.Gender = Gender;
            }
            else
            {
                throw new RegistrationException("Please fill all fields!");
            }



            //OPTIMIZE: Вынести в отдельный метод
            #region Phone Mail tryCatch

            //OPTIMIZE: Переделать в один блок try catch
            //IDEA: В Validator добавить разные виды исключения. Так легче будет ловить их.
            try
            {
                newUser.Email = Validator.GetEmail(Email);
            }
            catch
            {
                throw new RegistrationException("Invalid Email!");
            }

            try
            {
                newUser.Phone = Validator.GetPhone(Phone);
            }
            catch
            {
                throw new RegistrationException("Invalid phone!");
            }
            #endregion

            newUser.Password = ValidatePassword() ? Password :
                throw new RegistrationException("Passwords are not same!");

            return newUser;
        }


        public RelayCommand<User> RegCommand => _regCommand ??= new RelayCommand<User>(
                param =>
                {
                    try
                    {
                        User user = CreateUser();
                        Messenger.Send(new UserNullMoneyMessage()
                        {
                            User = user
                        });
                        NavigationService.NavigateTo<Balance_ViewModel>();
                    }
                    catch (RegistrationException regError)
                    {
                        MessageBox.Show(regError.Message);
                    }
                   
                });
    }
}