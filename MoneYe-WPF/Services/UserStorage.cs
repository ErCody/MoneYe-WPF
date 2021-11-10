using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    public class UserStorage
    {
        private FileService FileService { get; set; }
        private UserStorage()
        {
            FileService = new FileService();
            FileService.FilePath = "users.json";
            Users = FileService.IsExistsOrNotNull()
                ? Load()
                : new ObservableCollection<User>();


        }
        private ObservableCollection<User> Users { get; set; }
        //private bool validateUser(Email email)
        //{
        //    //try
        //    //{
        //    //    var result = Users.Single(x =>
        //    //        x.Email.Address == email.Address);
        //    //    return Users.;
        //    //}
        //    //catch
        //    //{
        //    //    return false;
        //    //}
        //}

        private static UserStorage _instance;

        public static UserStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserStorage();
                }
                return _instance;
            }
        }

        public void AddUser(User newUser)
        {
            //if (validateUser(newUser.Email))
            //{
            //    Users.Add(newUser);
            //    Upload();
            //}
            //else
            //{
            //    throw new Exception("User already exist!");
            //}
            Users.Add(newUser);
            Upload();

        }
        public void DeleteUser(User user)
        { 
            Users.Remove(user);
            Upload();
        }
        public void EditUser(User oldUser, User newUser)
        {
            var idx = Users.IndexOf(oldUser);
            Users[idx] = newUser;
            Upload();
        }
        public User GetUserByLoginInfo(Email email, string password)
        {
            try
            {
                var result = Users.Single(x =>
                    x.Email.Address == email.Address &&
                    x.Password == password);
                return result;
            } catch { throw; }
        }

        private void Upload()
        {
            var json = JsonSerializer.Serialize(Users);
            FileService.Write(json, FileMode.OpenOrCreate);
        }

        private ObservableCollection<User> Load()
        {
            var json = FileService.Read();
            var result = JsonSerializer.Deserialize<ObservableCollection<User>>(json);
            return result;

        }
    }
}