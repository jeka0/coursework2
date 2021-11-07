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
        IPresenter presenter { get; set; }
        String GetDate();
        String GetTime();
        String GetCategory();
        String GetComment();
        void SetSum(String value);
        double GetAmount();
        void SetLogin(String value);
        void SetSurname(String value);
        void SetName(String value);
        ComboBox GetCategories();
        ComboBox GetCategories2();
        Chart GetGeneralSchedule();
        Chart GetCategoryChart();
        int GetIndx();
        int GetRecordType();
        int GetSortType();
        int GetReportType();
        String GetNewCategory();
        Label GetLabel();
        DataGridView GetDataGridView();
    }
}
