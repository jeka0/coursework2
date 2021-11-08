using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataAccessLayer;

namespace Курсовой_проект_2
{
    public partial class MainForm : Form, IMainView
    {
        public IPresenter presenter { get; set; }
        public void SetLogin(String value) { login0.Text = value; } 
        public void SetSurname(String value) { Surname0.Text = value; }
        public void SetName(String value) { name0.Text = value; }
        public void SetSum(String value) { labelSum.Text = value; }
        public ComboBox GetCategories() { return Categories; }
        public ComboBox GetCategories2() { return Categories2; }
        public int GetIndx() { return tabControl1.SelectedIndex; }
        public Chart GetGeneralSchedule() { return GeneralSchedule; }
        public Chart GetCategoryChart() { return CategoryChart; }
        public Label GetLabel()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return NoExpenses;
            else
            if (indx == 1) return NoIncome;
            else
            if (indx == 2) return NoHistory; else return null;
        }
        public String GetNewCategory()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return NewCategories.Text;
            else
            if (indx == 1) return NewCategories2.Text; else return null;
        }
        public DataGridView GetDataGridView()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return dataGridView1;
            else
                if (indx == 1) return dataGridView2;
            else
                if (indx == 2) return dataGridView3;
            else return null;
        }
        public DataGridView[] GetDataGridViewReports()
        {
            return new DataGridView[] { dataGridViewReport1, dataGridViewReport2 };
        }
        public String GetDate()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Date.Value.ToShortDateString();
            else
                if (indx == 1) return Date2.Value.ToShortDateString();
            else
                if (indx == 2) return Date3.Value.ToShortDateString();
            else return null;
        }
        public String GetTime()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Time.Value.ToLongTimeString();
            else
            if (indx == 1) return Time2.Value.ToLongTimeString(); else return null;
        }
        public String GetCategory()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Categories.Text;
            else
            if (indx == 1) return Categories2.Text; else return null;
        }
        public String GetComment()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Comment.Text;
            else
            if (indx == 1) return Comment2.Text; else return null;
        }
        public double GetAmount()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Convert.ToDouble(Amount.Text) * (-1);
            else
            if (indx == 1) return Convert.ToDouble(Amount2.Text); else return 0;
        }
        public int GetRecordType()
        {
            if (radioButtonAll.Checked) return 0;
            else if (radioButtonExpenses.Checked) return 1;
            else return 2;
        }
        public int GetReportType()
        {
            if (radioButtonIncomeReport.Checked) return 0;
            else return 1;
        }
        public int GetSortType()
        {
            if (radioButtonTime.Checked) return 0;
            else return 1;
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            tabControl1.Multiline = true;
            Date.Format = DateTimePickerFormat.Short; Date2.Format = DateTimePickerFormat.Short;
            Time.Format = DateTimePickerFormat.Time; Time2.Format = DateTimePickerFormat.Time;
            DateTime minDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), maxDate = minDate.AddDays(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - 1);
            Date.MinDate = minDate; Date.MaxDate = maxDate; Date2.MinDate = minDate; Date2.MaxDate = maxDate;
            Date.ShowUpDown = true; Date2.ShowUpDown = true;
            Time.ShowUpDown = true; Time2.ShowUpDown = true;
            Categories.DropDownStyle = ComboBoxStyle.DropDownList; Categories2.DropDownStyle = ComboBoxStyle.DropDownList;
            Categories.Text = "Общее"; Categories2.Text = "Общее";
            presenter.UpdateUserData();
            presenter.LoadElements();
            tabControl1.SelectTab(1);
            presenter.LoadElements();
            tabControl1.SelectTab(2);
            presenter.UpdateHistory();
            tabControl1.SelectTab(0);
            presenter.UpdateCharts();

        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            presenter.SaveAccount();
            Application.Exit();
        }

        private void Expenses_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            tabControl1.SelectTab(0);
        }

        private void Income_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            tabControl1.SelectTab(1);
        }

        private void History_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            tabControl1.SelectTab(2);
        }

        private void Report_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            presenter.UpdateCharts();
            tabControl1.SelectTab(3);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            double amount;
            if (!(Amount.Text == "" || Amount.Text == "Введите сумму") && Double.TryParse(Amount.Text,out amount) && amount>0)
            {
                NoExpenses.Hide();
                presenter.UpdateElements();
                presenter.UpdateSum();
            }
            else Error3.Show();
        }

        private void AddCategories_Click(object sender, EventArgs e)
        {
            Error3.Hide();
            if (!(NewCategories.Text == "" || NewCategories.Text == "Введите категорию"))
            {
                if (!presenter.CheckCategories())
                {
                    Error1.Hide();
                    Error2.Hide();
                    Categories.Items.Add(NewCategories.Text);
                    presenter.AddCategory();
                }
                else Error1.Show();
            }
            else Error2.Show();
        }

        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == '|') e.Handled = true;
            if (e.KeyChar == 13) { Add.PerformClick(); e.Handled = true; }
        }

        private void Comment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|') e.Handled = true;
            if (e.KeyChar == 13) { Amount.Focus(); e.Handled = true; }
        }

        private void NewCategories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|') e.Handled = true;
            if (e.KeyChar == 13) { AddCategories.PerformClick(); e.Handled = true; }
        }

        private void Add2_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            double amount;
            if (!(Amount2.Text == "" || Amount2.Text == "Введите сумму") && Double.TryParse(Amount2.Text, out amount) && amount > 0)
            {
                NoIncome.Hide();
                presenter.UpdateElements();
                presenter.UpdateSum();
            }
            else Error3.Show();
        }

        private void AddCategories2_Click(object sender, EventArgs e)
        {
            Error3.Hide();
            if (!(NewCategories2.Text == "" || NewCategories2.Text == "Введите категорию"))
            {
                if (!presenter.CheckCategories())
                {
                    Error1.Hide();
                    Error2.Hide();
                    Categories2.Items.Add(NewCategories2.Text);
                    presenter.AddCategory();
                }
                else Error1.Show();
            }
            else Error2.Show();
        }

        private void Amount2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == '|') e.Handled = true;
            if (e.KeyChar == 13) { Add2.PerformClick(); e.Handled = true; }
        }

        private void Comment2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|') e.Handled = true;
            if (e.KeyChar == 13) { Amount2.Focus(); e.Handled = true; }
        }

        private void NewCategories2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|') e.Handled = true;
            if (e.KeyChar == 13) { AddCategories2.PerformClick(); e.Handled = true; }
        }

        private void NewCategories_Enter(object sender, EventArgs e)
        {
            if (NewCategories.Text == "Введите категорию") NewCategories.Text = "";
        }

        private void NewCategories_Leave(object sender, EventArgs e)
        {
            if (NewCategories.Text == "") NewCategories.Text = "Введите категорию";
        }

        private void NewCategories2_Enter(object sender, EventArgs e)
        {
            if (NewCategories2.Text == "Введите категорию") NewCategories2.Text = "";
        }

        private void NewCategories2_Leave(object sender, EventArgs e)
        {
            if (NewCategories2.Text == "") NewCategories2.Text = "Введите категорию";
        }

        private void Comment_Enter(object sender, EventArgs e)
        {
            if (Comment.Text == "Введите комментарий") Comment.Text = "";
        }

        private void Comment_Leave(object sender, EventArgs e)
        {
            if (Comment.Text == "") Comment.Text = "Введите комментарий";
        }

        private void Comment2_Enter(object sender, EventArgs e)
        {
            if (Comment2.Text == "Введите комментарий") Comment2.Text = "";
        }

        private void Comment2_Leave(object sender, EventArgs e)
        {
            if (Comment2.Text == "") Comment2.Text = "Введите комментарий";
        }

        private void Amount_Enter(object sender, EventArgs e)
        {
            if (Amount.Text == "Введите сумму") Amount.Text = "";
        }

        private void Amount_Leave(object sender, EventArgs e)
        {
            if (Amount.Text == "") Amount.Text = "Введите сумму";
        }

        private void Amount2_Enter(object sender, EventArgs e)
        {
            if (Amount2.Text == "Введите сумму") Amount2.Text = "";
        }

        private void Amount2_Leave(object sender, EventArgs e)
        {
            if (Amount2.Text == "") Amount2.Text = "Введите сумму";
        }

        private void Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) e.Handled=true;
        }

        private void Time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) e.Handled = true;
        }

        private void Date2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) e.Handled = true;
        }

        private void Time2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) e.Handled = true;
        }

        private void Date3_ValueChanged(object sender, EventArgs e)
        {
            presenter.UpdateHistory();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            presenter.UpdateHistory();
        }

        private void radioButtonExpenses_CheckedChanged(object sender, EventArgs e)
        {
            presenter.UpdateHistory();
        }

        private void radioButtonIncome_CheckedChanged(object sender, EventArgs e)
        {
            presenter.UpdateHistory();
        }

        private void radioButtonTime_CheckedChanged(object sender, EventArgs e)
        {
            presenter.UpdateHistory();
        }

        private void radioButtonAmount_CheckedChanged(object sender, EventArgs e)
        {
            presenter.UpdateHistory();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            presenter.UpdateHistory();
        }

        private void radioButtonIncomeReport_CheckedChanged(object sender, EventArgs e)
        {
            presenter.UpdateCharts();
        }

        private void radioButtonExpenseReport_CheckedChanged(object sender, EventArgs e)
        {
            presenter.UpdateCharts();
        }
    }
}
