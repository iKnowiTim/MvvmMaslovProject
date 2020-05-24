using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
//Реализация отстой, не использовал, можете не смотреть
namespace MvvmMaslovProject.Model
{
    static class ManagerPages 
    {
        static PageMain _currentPage;
        static public PageMain CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }

        static public void ChangePage(PageMain page)
        {
            
        }
    }
}
