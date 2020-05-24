using MvvmMaslovProject.Model;
using MvvmMaslovProject.Pages;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MvvmMaslovProject.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        [Obsolete]
        public MainWindowViewModel()
        {
            InitPages();
            InitCommand();
        }
        //Создание переменных на основе типов ViewModel, чтобы перемещаться по компонентам
        private PageLoginViewModel Login;
        private PageRegisterViewModel Registration;
        private ExcelViewModel Excel;
        private ProfileViewModel Profile;
        
        // Инициализация Команд
        public void InitCommand()
        {
            ProfileCommand = new RelayCommand(() => SwitchPage("Profile"));
            PageLogin = new RelayCommand(() => SwitchPage("Login"));
            PageRegister = new RelayCommand(() => SwitchPage("Register"));
            PageExcel = new RelayCommand(() => SwitchPage("Excel"));
            ExitAccountCommand = new RelayCommand(Exit);
        }
        //Инициализация компонентов
        [Obsolete]
        public void InitPages()
        {
            Login = new PageLoginViewModel(this);
            Registration = new PageRegisterViewModel(this);
            Excel = new ExcelViewModel(this);
            Profile = new ProfileViewModel(this);
            _currentPage = Login;
        }

        #region Свойства
        

        public event PropertyChangedEventHandler PropertyChanged;
        //свойство, которое отвечает за Visible StackPanal в MainWindow.xaml
        private bool _signedIn;

        public bool SignedIn
        {
            get { return _signedIn; }
            set 
            { 
                _signedIn = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SignedIn)));
            }
        }

        //Свойство текущая страница
        private BaseViewModel _currentPage;
        public BaseViewModel CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
            }
        }
        
        #endregion
        //Все, что мы делали ранее, нужно для этого. Позволяет перемещаться из любого компонента в другой компонент.
        public void SwitchPage(string pageName)
        {
            switch (pageName)
            {
                case "Login":
                    CurrentPage = Login;
                    break;
                case "Register":
                    CurrentPage = Registration;
                    break;
                case "Excel":
                    CurrentPage = Excel;
                    break;
                case "Profile":
                    CurrentPage = Profile;
                    Profile.LoadInfo();
                    break;
                    
                default:
                    break;
            }
        }

        public void SignIn()
        {
            SwitchPage("Excel");
            SignedIn = true;
        }

        public void Exit()
        {
            SwitchPage("Login");
            SignedIn = false;
        }



        #region Commands
        public ICommand PageLogin { get; set; }
        public ICommand PageRegister { get; set; }
        public ICommand PageExcel { get; set; }
        public ICommand ExitAccountCommand { get; set; }
        public ICommand ProfileCommand { get; set; }
        #endregion
    }
}
