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
        public PresentersContainer Presenters { get; set; }
        public void SetLogin(String value) { login0.Text = value; } 
        public void SetSurname(String value) { Surname0.Text = value; }
        public void SetName(String value) { name0.Text = value; }
        public void SetSum(String value) { textSum.Text = value; }
        public void SetAmountPerDay(String value) { textBoxAmountPerDay.Text = value; }
        public void SetMonthlyAmount(String value) { textBoxMonthlyAmount.Text = value; }
        public int GetIndx() { return tabControl1.SelectedIndex; }
        public Chart GetGeneralSchedule() { return GeneralSchedule; }
        public Chart GetCategoryChart() { return CategoryChart; }
        public DataGridView GetCategoryTable() { return dataGridViewReport1; }
        public DataGridView GetTableOfMonths() { return dataGridViewReport2; }
        public bool Deleting { get; set; } = false;
        public Label GetLabel()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return NoExpenses; else if (indx == 1) return NoIncome; else if (indx == 2) return NoHistory; else if (indx == 3) return NoCategories; else return null;
        }

        public ComboBox GetCategories()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Categories; else if (indx == 1) return Categories2; else return null;
        }

        public String GetNewCategory()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) { if (NewCategories.Text == "Введите категорию") return ""; else return NewCategories.Text; } else if (indx == 1) { if (NewCategories2.Text == "Введите категорию") return ""; else return NewCategories2.Text; } else return null;
        }

        public DataGridView GetDataGridView()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return dataGridView1; else if (indx == 1) return dataGridView2; else if (indx == 2) return dataGridView3; else return null;
        }

        public String GetDate()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Date.Value.ToShortDateString(); else if (indx == 1) return Date2.Value.ToShortDateString(); else if (indx == 2) return Date3.Value.ToShortDateString(); else return null;
        }

        public String GetTime()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Time.Value.ToLongTimeString(); else if (indx == 1) return Time2.Value.ToLongTimeString(); else return null;
        }

        public String GetCategory()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Categories.Text; else if (indx == 1) return Categories2.Text; else return null;
        }

        public String GetComment()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) { if (Comment.Text == "Введите комментарий"|| Comment.Text == "") return "-";else return Comment.Text; } else if (indx == 1) { if (Comment2.Text == "Введите комментарий" || Comment2.Text == "") return "-"; else return Comment2.Text; } else return null;
        }

        public String GetAmount()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) { if (Amount.Text == "Введите сумму") return ""; else return Amount.Text; } else if (indx == 1) { if (Amount2.Text == "Введите сумму") return ""; else return Amount2.Text; } else return null;
        }

        public int GetRecordType()
        {
            if (radioButtonAll.Checked) return 0; else if (radioButtonExpenses.Checked) return 1; else return 2;
        }

        public int GetReportType()
        {
            if (radioButtonIncomeReport.Checked) return 0; else return 1;
        }

        public int GetSortType()
        {
            if (radioButtonTime.Checked) return 0; else return 1;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private TextBox IdentifyAmount()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Amount; else return Amount2;
        }

        private Button IdentifyAdd()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return Add; else return Add2;
        }

        private Button IdentifyAddCategories()
        {
            int indx = tabControl1.SelectedIndex;
            if (indx == 0) return AddCategories; else return AddCategories2;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Presenters.MainPresenter.Views.Clean();
            Presenters.MainPresenter.Views.MainView = this;
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            DateTime minDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), maxDate = minDate.AddDays(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - 1);
            Date.MinDate = minDate; Date.MaxDate = maxDate; Date2.MinDate = minDate; Date2.MaxDate = maxDate;
            Presenters.MainPresenter.UpdateUserData();
            Presenters.MainPresenter.LoadElements();
            Presenters.MainPresenter.UpdateСategories();
            tabControl1.SelectTab(1);
            Presenters.MainPresenter.LoadElements();
            Presenters.MainPresenter.UpdateСategories();
            tabControl1.SelectTab(2);
            Presenters.MainPresenter.UpdateHistory();
            tabControl1.SelectTab(3);
            Presenters.MainPresenter.UpdateCharts();
            tabControl1.SelectTab(0);
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if(!Deleting) Presenters.MainPresenter.SaveAccount();
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
            tabControl1.SelectTab(3);
            Presenters.MainPresenter.UpdateCharts();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            if (Presenters.MainPresenter.ValidateString(GetAmount()) && Presenters.MainPresenter.ValidateAmount())
            {
                NoExpenses.Hide();
                Presenters.MainPresenter.UpdateElements();
                Presenters.MainPresenter.UpdateSum();
            }
            else Error3.Show();
        }

        private void AddCategories_Click(object sender, EventArgs e)
        {
            Error3.Hide();
            Error1.Hide();
            Error2.Hide();
            if (Presenters.MainPresenter.ValidateString(GetNewCategory()))
            {
                if (!Presenters.MainPresenter.CheckCategories())
                {
                    Error1.Hide();
                    Error2.Hide();
                    Presenters.MainPresenter.AddCategory();
                    Presenters.MainPresenter.UpdateСategories();
                }
                else Error1.Show();
            }
            else Error2.Show();
        }

        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == 13) { IdentifyAdd().PerformClick(); e.Handled = true; }
        }

        private void Comment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { IdentifyAmount().Focus(); e.Handled = true; }
        }

        private void NewCategories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { IdentifyAddCategories().PerformClick(); e.Handled = true; }
        }

        private void NewCategories_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "Введите категорию") ((TextBox)sender).Text = "";
        }

        private void NewCategories_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите категорию";
        }

        private void Comment_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "Введите комментарий") ((TextBox)sender).Text = "";
        }

        private void Comment_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите комментарий";
        }

        private void Amount_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "Введите сумму") ((TextBox)sender).Text = "";
        }

        private void Amount_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "") ((TextBox)sender).Text = "Введите сумму";
        }

        private void ButtonLockEvent(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) e.Handled = true;
        }

        private void UpdateHistoryEvent(object sender, EventArgs e)
        {
            Presenters.MainPresenter.UpdateHistory();
        }

        private void UpdateChartsEvent(object sender, EventArgs e)
        {
            Presenters.MainPresenter.UpdateCharts();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Presenters = Presenters;
            form1.Show();
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point point;
        private void Border_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(45, 45, 48);
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Gray;
            ((Label)sender).ForeColor = Color.White;
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirmationForm = new ConfirmationForm();
            confirmationForm.mainForm = this;
            confirmationForm.ShowDialog();
            if (Deleting)
            {
                Presenters.MainPresenter.DeleteAccount();
                buttonExit_Click(sender, e);
            }
        }
    }
}
