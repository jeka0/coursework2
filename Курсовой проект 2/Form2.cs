using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;
using DataAccessLayer;

namespace Курсовой_проект_2
{
    public partial class Form2 : Form, IRegistrationView
    {
        bool clu11 = true, clu22 = true;
        public IPresenter presenter { get; set; }
        public String GetLogin { get { return login.Text; } }
        public String GetPassword { get { return pass.Text; } }
        public String GetSurname { get { return textBox3.Text; } }
        public String GetName { get { return textBox2.Text; } }
        public Point point2;
        public Form2()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.BackColor = Color.Gray;
            Exit.ForeColor = Color.White;
        }

        private void clue1_Click(object sender, EventArgs e)
        {
            if (clu11)
            {
                Clue11.Show(); clu11 = false;
            }
            else
            {
                Clue11.Hide(); clu11 = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (clu22)
            {
                Clue22.Show(); clu22 = false;
            }
            else
            {
                Clue22.Hide(); clu22 = true;
            }
        }
        Point point;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void login_Enter(object sender, EventArgs e)
        {
            if (login.Text == "Введите логин") login.Text = "";
        }

        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text == "") login.Text = "Введите логин";
        }

        private void pass_Enter(object sender, EventArgs e)
        {
            if (pass.Text == "Введите пароль") pass.Text = "";
        }

        private void pass_Leave(object sender, EventArgs e)
        {
            if (pass.Text == "") pass.Text = "Введите пароль";
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == 13) { textBox2.Focus(); e.Handled = true; }
        }

        private void pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == 13) { Enter.PerformClick(); e.Handled = true; }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.point2 = this.Location;
            presenter.authorizationView = form1;
            form1.presenter = presenter;
            form1.Show();
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == 13) { textBox3.Focus(); e.Handled = true; }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == 13) { pass.Focus(); e.Handled = true; }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите имя") textBox2.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "") textBox2.Text = "Введите имя";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Введите фамилию") textBox3.Text = "";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "") textBox3.Text = "Введите фамилию";
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error0.Hide();
            Error3.Hide();
            if (!(login.Text== "Введите логин"|| login.Text == ""|| pass.Text == "Введите пароль" || pass.Text == "" || textBox2.Text == "Введите имя" || textBox2.Text == "" || textBox3.Text == "Введите фамилию" || textBox3.Text == ""))
            {
                //try
               // {
                    bool err=false;
                    if (!err)
                    {
                        if (presenter.UserRegistration())
                        {
                            presenter.CreateNewUser();
                            MainForm main = new MainForm();
                            presenter.mainView = main;
                            main.presenter = presenter;
                            main.Show();
                            this.Close();
                        }
                        else Error2.Show();
                    }else Error3.Show();
               // }
                //catch { Error0.Show(); }
            }
            else Error1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = point2;
            Clue11.Hide();
            Clue22.Hide();
            Error1.Hide();
            Error2.Hide();
            Error0.Hide();
            Error3.Hide();
        }
    }
}
