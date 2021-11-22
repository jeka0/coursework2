using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public interface IMainPresenter
    {
        ViewsContainer Views { get; set; }
        void UpdateUserData();
        void UpdateСategories();
        void LoadСategories();
        void LoadMonthlyReports();
        void UpdateElements();
        void LoadElements();
        bool CheckCategories();
        void AddCategory();
        void UpdateSum();
        void SaveAccount();
        void UpdateHistory();
        void UpdateCharts();
        void DeleteAccount();
        bool ValidateAmount();
        bool ValidateString(String str);
    }
}
