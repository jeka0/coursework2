using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataAccessLayer
{
    public interface IMainView
    {
        PresentersContainer Presenters { get; set; }
        String GetDate();
        String GetTime();
        String GetCategory();
        String GetComment();
        void SetSum(String value);
        void SetAmountPerDay(String value);
        String GetAmount();
        void SetLogin(String value);
        void SetSurname(String value);
        void SetName(String value);
        ComboBox GetCategories();
        Chart GetGeneralSchedule();
        Chart GetCategoryChart();
        int GetIndx();
        int GetRecordType();
        int GetSortType();
        int GetReportType();
        String GetNewCategory();
        Label GetLabel();
        DataGridView GetDataGridView();
        DataGridView GetCategoryTable();
        DataGridView GetTableOfMonths();
    }
}
