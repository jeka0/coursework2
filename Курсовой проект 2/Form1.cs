using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace Курсовой_проект_2
{
    public partial class Form1 : Form, IAuthorizationView
    {
        bool clu11 = true, clu22 = true;
        public PresentersContainer Presenters { get; set; }
        public String GetLogin() { if (login.Text == "Введите логин") return ""; else return login.Text; }
        public String GetPassword() { if (pass.Text == "Введите пароль") return ""; else return pass.Text; }
        public Point point2 = new Point(550,300);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Presenters.LoginPresenter.Views.Clean();
            Presenters.LoginPresenter.Views.AuthorizationView = this;
            this.Location = point2;
            Clue11.Hide();
            Clue22.Hide();
            Error1.Hide();
            Error2.Hide();
            Error0.Hide();
            Error0.Hide();
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

        private void clue2_Click(object sender, EventArgs e)
        {
            if (clu22){ Clue22.Show(); clu22 = false; }
            else { Clue22.Hide(); clu22 = true; }
        }
        Point point;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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
            pass.PasswordChar = '*';
        }

        private void pass_Leave(object sender, EventArgs e)
        {
            pass.PasswordChar = '\0';
            if (pass.Text == "") pass.Text = "Введите пароль";
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == 13) { pass.Focus(); e.Handled = true; }
        }

        private void pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
            if (e.KeyChar == 13) { Enter.PerformClick(); e.Handled = true; }
            }
        private void textBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 =  new Form2();
            form2.point2 = this.Location;
            form2.Presenters = Presenters;
            form2.Show();
            this.Close();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            Error1.Hide();
            Error2.Hide();
            Error0.Hide();
            Error0.Hide();
            if (Presenters.LoginPresenter.ValidateString(GetLogin()) && Presenters.LoginPresenter.ValidateString(GetPassword()))
            {
                try 
                {
                    if (Presenters.LoginPresenter.UserAuthorization())
                    {
                        MainForm main = new MainForm();
                        main.Presenters = Presenters;
                        main.Show();
                        this.Close();
                    }
                    else Error2.Show();
                }
                catch { Error0.Show(); }
            }
            else Error1.Show();
        }

        private void clue1_Click(object sender, EventArgs e)
        {
            if (clu11){ Clue11.Show(); clu11 = false; }else{ Clue11.Hide(); clu11 = true; }
        }
    }
}
