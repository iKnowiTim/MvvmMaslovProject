using MvvmMaslovProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmMaslovProject.ViewModel
{
    class ProfileViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private MainWindowViewModel _mainWindowViewModel;
        public ProfileViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            InitCommands();
        }

        public void InitCommands()
        {

        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }

        public void LoadInfo()
        {
            var user = UserManager.GetInfo();
            _name = user.Name;
            _lastName = user.LastName;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
