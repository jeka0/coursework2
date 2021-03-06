using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using BusinessLayer;
using DataAccessLayer;

namespace ServiceLayer
{
    public class SupportingWork
    {
        public static IMainView mainView { get; set; }
        public static void FillInCategoryReport(List<Category> list)
        {
            Chart categoryChart = mainView.GetCategoryChart();
            var table = mainView.GetCategoryTable(); var label = mainView.GetLabel();
            categoryChart.Series[0].Points.Clear(); table.Rows.Clear();
            if (list.Count != 0) label.Hide(); else label.Show();
            foreach (var item in list)
            {
                categoryChart.Series[0].Points.AddXY(item.Name, item.Percent);
                table.Rows.Add(item.Name, item.Percent + " %", item.GetStrAmount());
            }
            table.ClearSelection();
        }
        public static void FillInMonthlyReport(List<MonthlyReport> monthlyReports)
        {
            Chart generalSchedule = mainView.GetGeneralSchedule();
            var table = mainView.GetTableOfMonths();
            generalSchedule.Series[0].Points.Clear(); table.Rows.Clear();
            double oldValue = 0;
            foreach (var item in monthlyReports)
            {
                double value = item.GetTotalAmount(mainView.GetReportType());
                Bitmap picture;
                if (value < oldValue) picture = Properties.Resource.Down; else picture = Properties.Resource.Up;
                generalSchedule.Series[0].Points.AddXY(item.Date, item.ConvertToInt32(value));
                table.Rows.Add(item.Date, picture, "на " + item.AmountToString(value - oldValue), item.AmountToString(value));
                oldValue = value;
            }
            table.Sort(table.Columns[0], System.ComponentModel.ListSortDirection.Descending);
            table.ClearSelection();
        }
    }
}
