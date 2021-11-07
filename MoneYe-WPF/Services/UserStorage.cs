using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    public class UserStorage: IUserStorage
    {
        private ObservableCollection<User> Users { get; set; }
        private User GetUserByLogin(string login)
        {
            try
            {
                var result = Users.Single(x =>
                    x.Login == login);
                return result;
            }
            catch { throw; }
        }

        public IEnumerable<User> GetUsers()
        {
            return Users;
        }
        public void AddUser(User user)
        {
            try
            {
                var _user = GetUserByLogin(user.Login);
                throw new Exception("User already exist!");
            }
            catch { Users.Add(user); }
        }
        public void DeleteUser(User user)
        { 
            Users.Remove(user);
        }
        public void EditUser(User oldUser, User newUser)
        {
            int idx = Users.IndexOf(oldUser);
            Users[idx] = newUser;
        }
        public User GetUserByLoginInfo(string login, string password)
        {
            try
            {
                var result = Users.Single(x =>
                    x.Login == login &&
                    x.Password == password);
                return result;
            } catch { throw; }
        }
    }
}