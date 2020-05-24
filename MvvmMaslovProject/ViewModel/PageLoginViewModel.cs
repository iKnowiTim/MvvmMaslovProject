using MvvmMaslovProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MvvmMaslovProject.ViewModel
{
    public class PageLoginViewModel : INotifyPropertyChanged
    {
        [Obsolete]
        public PageLoginViewModel()
        {
            InitCommand();
        }

        [Obsolete]
        public void InitCommand()
        {
            SignIn = new RelayCommand(Login, CanPressBtnSignIn);
        }

        #region Свойства
        private string _userLogin = "";
        public string UserLogin
        {
            get { return _userLogin; }
            set 
            { 
                _userLogin = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(UserLogin)));
            }
        }

        private string _userPassword = "";
        public string UserPassword
        {
            get { return _userPassword; }
            set 
            { 
                _userPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(UserPassword)));
            }
        }
        #endregion

        public bool CanPressBtnSignIn(object parameter)
        {
            return UserLogin.Length > 0 && UserPassword.Length > 0;
        }

        public ICommand SignIn { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [Obsolete]
        public void Login()
        {
            UserManager.LoginUser(UserLogin, UserPassword);
        }
    }
}
