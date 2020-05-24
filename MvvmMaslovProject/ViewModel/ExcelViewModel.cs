using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmMaslovProject.Model;
using MvvmMaslovProject.ModelDb;

namespace MvvmMaslovProject.ViewModel
{
    public class ExcelViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private MainWindowViewModel _mainWindowViewModel;
        public ExcelViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            //Подгрузка данных в Свойство MaslovExcels
            PeopleEntities db = new PeopleEntities();
            db.MaslovExcel.Load();
            MaslovExcels = db.MaslovExcel.Local.ToBindingList();
        }
        //Создание свойства, в которую загрузим данные таблицы
        private IEnumerable<MaslovExcel> _maslovExcel;
        public IEnumerable<MaslovExcel> MaslovExcels
        {
            get
            {
                return _maslovExcel;
            }
            set
            {
                _maslovExcel = value;
                OnPropertyChanged("MaslovExcels");
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        private string _date;
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }


        //Реакция на изменение
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }




    }

    
}
