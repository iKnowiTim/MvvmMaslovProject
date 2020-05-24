using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmMaslovProject.ModelDb;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;

namespace MvvmMaslovProject.Model
{
    static class UserManager
    {
        private static User _users { get; set; }
        private static PeopleEntities db = new PeopleEntities();

        //Регистрация пользователя
        public static void RegistrationUser(string name, string lastName, string login, string password)
        {
            _users = new User(name, lastName, login, password);
            db.User.Add(_users);
            MessageBox.Show("Успешно зарегестрирован!");
            db.SaveChanges();
        }

        //Вход пользователя
        [System.Obsolete]
        public static bool LoginUser(string login, string password)
        {
            db = new PeopleEntities();
            db.User.Load();

            var user = db.User
                .Where(u => u.Login == login && u.Password == password)
                .FirstOrDefault();
            
            if (user != null)
            {//Присваивание данных, чтобы потом использовать их в личном кабинете
                _users = user;
                return true;
            }
                
            else 
                return false;
        }

        //То что присвоили, возращаем.
        public static User GetInfo()
        {
            return _users;
        }
    }
}
