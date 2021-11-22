using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
     public interface IModel
     {
        Elements Expenses { get; set; }
        Elements Income { get; set; }
        User SelectedUser { get; set; }
        List<User> Users { get; set; }
        MonthlyReport SelectedMonthlyReport { get; set; }
        List<MonthlyReport> MonthlyReports { get; set; }
        void Save<T>(String file, T item);
        T Read<T>(String file);
        void CreateFolder(String folder);
        void DeleteFile(String file);
        void DeleteFolder(String folder);
     }
}
