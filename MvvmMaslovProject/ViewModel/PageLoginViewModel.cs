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
    public class PageLoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private MainWindowViewModel _mainWindowViewModel;    
        [Obsolete]
        public PageLoginViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            InitCommand();
        }

        
        

        [Obsolete]
        public void InitCommand()
        {
            GoRegisterCommand = new RelayCommand(GoRegister, x => true);
            SignInCommand = new RelayCommand(Login, CanPressBtnSignIn);
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

        public ICommand SignInCommand { get; set; }

        public ICommand GoRegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        //Проверка на вход
        [Obsolete]
        public void Login()
        {
            bool success = UserManager.LoginUser(UserLogin, UserPassword);
            if (success)
            {
                _mainWindowViewModel.SignIn();
            }
            else MessageBox.Show("Не верно введен пароль или логин!");
        }
        public void GoRegister()
        {
            _mainWindowViewModel.SwitchPage("Register");
        }
        
    }
}
