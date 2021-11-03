using System.Collections.Generic;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    public interface IUserStorage
    {
        public void AddUser(User user);

        public void DeleteUser(User user);

        public void EditUser(User oldUser, User newUser);

        public User GetUserByLoginInfo(string login, string password);

        public IEnumerable<User> GetUsers();

    }
}