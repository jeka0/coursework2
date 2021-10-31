using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовой_проект_2
{
    public partial class MainForm : Form
    {
        public static String Login;
        public static String pass;
        private static String[] NameMas;
        private static TextBox[] Old = new TextBox[2] {null,null };
        private int[] index = new int[2] { 10, 10 };
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
            Date.ShowUpDown = true; Date2.ShowUpDown = true;
            Time.ShowUpDown = true; Time2.ShowUpDown = true;
            Categories.DropDownStyle = ComboBoxStyle.DropDownList; Categories2.DropDownStyle = ComboBoxStyle.DropDownList;
            Database.ReadCategoriesFromFile(Login, Categories, Categories2);
            Categories.Text = "Общее"; Categories2.Text = "Общее";
            NameMas = Database.ReadNameFromFile(Login);
            login0.Text = Login; name0.Text = NameMas[0]; Surname0.Text = NameMas[1];
            if (!Database.IsFileEmpty(Login, "Expenses")) { ApplicationWork.AddElementFromFile("Expenses", Login,ref Old[0], ref index[0], Screen); NoExpenses.Hide(); }
            tabControl1.SelectTab(1);
            if (!Database.IsFileEmpty(Login, "Income")) { ApplicationWork.AddElementFromFile("Income", Login,ref Old[1], ref index[1], Screen2); NoIncome.Hide(); }
            tabControl1.SelectTab(0);

        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
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
            tabControl1.SelectTab(3);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error3.Hide();
            if (!(Comment.Text == "" || Comment.Text == "Введите комментарий" || Amount.Text == "" || Amount.Text == "Введите сумму"))
            {
                String DateStr = Date.Value.Day.ToString() + '.' + Date.Value.Month.ToString() + '.' + Date.Value.Year.ToString();
                String TimeStr = Time.Value.Hour.ToString() + ':' + Time.Value.Minute.ToString() + ':' + Time.Value.Second.ToString();
                NoExpenses.Hide();
                ApplicationWork.AddNewElement(Login, ref Old[0], ref index[0], Screen, DateStr, TimeStr, Categories.Text, Comment.Text, Amount.Text, "Expenses", true);
            }
            else Error3.Show();
        }

        private void AddCategories_Click(object sender, EventArgs e)
        {
            Error3.Hide();
            if (!(NewCategories.Text == "" || NewCategories.Text == "Введите категорию"))
            {
                if (!ApplicationWork.CheckCategories(NewCategories.Text, Categories))
                {
                    Error1.Hide();
                    Error2.Hide();
                    Categories.Items.Add(NewCategories.Text);
                    Database.WriteUserData(Login, pass, NameMas[0], NameMas[1]);
                    Database.WriteNewCategorie(Login, Categories);
                    Database.WriteNewCategorie(Login, Categories2);
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
            if (!(Comment2.Text == "" || Comment2.Text == "Введите комментарий" || Amount2.Text == "" || Amount2.Text == "Введите сумму"))
            {
                String DateStr = Date2.Value.Day.ToString() + '.' + Date2.Value.Month.ToString() + '.' + Date2.Value.Year.ToString();
                String TimeStr = Time2.Value.Hour.ToString() + ':' + Time2.Value.Minute.ToString() + ':' + Time2.Value.Second.ToString();
                NoIncome.Hide();
                ApplicationWork.AddNewElement(Login, ref Old[1], ref index[1], Screen2, DateStr, TimeStr, Categories2.Text, Comment2.Text, Amount2.Text, "Income", true);
            }
            else Error3.Show();
        }

        private void AddCategories2_Click(object sender, EventArgs e)
        {
            Error3.Hide();
            if (!(NewCategories2.Text == "" || NewCategories2.Text == "Введите категорию"))
            {
                if (!ApplicationWork.CheckCategories(NewCategories2.Text, Categories2))
                {
                    Error1.Hide();
                    Error2.Hide();
                    Categories2.Items.Add(NewCategories2.Text);
                    Database.WriteUserData(Login, pass, NameMas[0], NameMas[1]);
                    Database.WriteNewCategorie(Login, Categories);
                    Database.WriteNewCategorie(Login, Categories2);
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
    }
}
