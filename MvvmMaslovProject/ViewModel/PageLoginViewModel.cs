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
        public PageLoginViewModel()
        {
            Register = new Pages.Register();
            PageRegister = new RelayCommand(ChangeCurrentPage);
        }

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

        public ICommand PageRegister { get; set; }
        

        public void ChangeCurrentPage()
        {
            
        }
    }
}
