using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmMaslovProject.Model
{
    public class PageMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PageMain _currentPage;
        public PageMain CurrentPage
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

        public PageMain Login;
        public PageMain Register;
    }
}
