using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовой_проект_2
{
    public partial class ConfirmationForm : Form
    {
        public MainForm mainForm;
        public ConfirmationForm()
        {
            InitializeComponent();
        }

        private void buttonYES_Click(object sender, EventArgs e)
        {
            mainForm.Deleting = true;
            this.Close();
        }

        private void buttonNO_Click(object sender, EventArgs e)
        {
            mainForm.Deleting = false;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(45, 45, 48);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Gray;
            ((Label)sender).ForeColor = Color.White;
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
    }
}
