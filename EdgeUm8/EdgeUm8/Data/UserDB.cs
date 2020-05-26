using System.Collections.Generic;
using EdgeUm8.Interfaces;
using EdgeUm8.Models;
using System.Linq;
using Xamarin.Forms;
using SQLite;

namespace EdgeUm8.Data
{
    public class UserDB
    {
        private SQLiteConnection _SQLiteConnection;
        public static int currentUserId { get; set; }

        public UserDB() {
            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();
            _SQLiteConnection.CreateTable<User>();
        }

        public string AddUser(User user) {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.Email == user.Email && x.UserName == user.UserName).FirstOrDefault();

            if (d1 == null) {
                _SQLiteConnection.Insert(user);
                return "User Sucessfully Registered!";
            } else {
                return "Already Mail id Exist";
            }

        }

        public IEnumerable<User> GetUsers() {

            return (from u in _SQLiteConnection.Table<User>()

                    select u).ToList();

        }

        public User GetSpecificUser(int id) {

            return _SQLiteConnection.Table<User>().FirstOrDefault(t => t.Id == id);

        }

        public void DeleteUser(int id) {

            _SQLiteConnection.Delete<User>(id);

        }

        

        public bool updateUserValidation(string userid) {

            var data = _SQLiteConnection.Table<User>();

            var d1 = (from values in data

                      where values.Email == userid

                      select values).Single();

            if (d1 != null) {

                return true;

            } else

                return false;

        }

        public bool updateUser(string username, string pwd) {

            var data = _SQLiteConnection.Table<User>();

            var d1 = (from values in data

                      where values.Email == username

                      select values).Single();

            if (true) {

                d1.Password = pwd;

                _SQLiteConnection.Update(d1);

                return true;

            } else {

                return false;
            }

        }

        public bool LoginValidate(string userName1, string pwd1) {

            var data = _SQLiteConnection.Table<User>();

            var d1 = data.Where(x => x.Email == userName1 && x.Password == pwd1).FirstOrDefault();

            

            if (d1 != null) {

                currentUserId = d1.Id;

                return true;

            } else

                return false;

        }

    }
}

