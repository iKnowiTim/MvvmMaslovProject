using MvvmMaslovProject.Pages;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MvvmMaslovProject.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            InitCommand();
            InitPages();
        }

        // Инициализация Команд
        public void InitCommand()
        {
            PageLogin = new RelayCommand(()=> CurrentPage = Login);
            PageRegister = new RelayCommand(()=> CurrentPage = Register);
        }

        public void InitPages()
        {
            Login = new Pages.Login();
            Register = new Pages.Register();
        }

        #region Свойства
        private Page Login;
        private Page Register;

        public event PropertyChangedEventHandler PropertyChanged;


        private Page _currentPage;
        public Page CurrentPage
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



        #region Commands
        public ICommand PageLogin { get; set; }
        public ICommand PageRegister { get; set; }
        #endregion
    }
}
