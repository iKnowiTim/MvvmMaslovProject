using MvvmMaslovProject.ModelDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmMaslovProject.Model
{
    static class ManagerExcel
    {
        
        private static List<MaslovExcel> _maslovExcels { get; set; }
        private static MaslovExcel _maslov { get; set; }
        private static PeopleEntities db;

        //Подгрузка Данных с сервера
        static ManagerExcel()
        {
            db.MaslovExcel.Load();
        }

        static public void GetExcel()
        {
            
        }
    }
}
