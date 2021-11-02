
namespace Курсовой_проект_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clue1 = new System.Windows.Forms.Label();
            this.clue2 = new System.Windows.Forms.Label();
            this.Clue11 = new System.Windows.Forms.Label();
            this.Clue22 = new System.Windows.Forms.Label();
            this.Enter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Error1 = new System.Windows.Forms.Label();
            this.Error2 = new System.Windows.Forms.Label();
            this.Error0 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(299, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 27);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Gray;
            this.Exit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Exit.Location = new System.Drawing.Point(777, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(22, 22);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "X";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // login
            // 
            this.login.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.ForeColor = System.Drawing.Color.Black;
            this.login.Location = new System.Drawing.Point(198, 141);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(347, 29);
            this.login.TabIndex = 2;
            this.login.Text = "Введите логин";
            this.login.Enter += new System.EventHandler(this.login_Enter);
            this.login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_KeyPress);
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // pass
            // 
            this.pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass.Location = new System.Drawing.Point(198, 208);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(347, 29);
            this.pass.TabIndex = 3;
            this.pass.Text = "Введите пароль";
            this.pass.Enter += new System.EventHandler(this.pass_Enter);
            this.pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pass_KeyPress);
            this.pass.Leave += new System.EventHandler(this.pass_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(193, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логин ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(193, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль";
            // 
            // clue1
            // 
            this.clue1.AutoSize = true;
            this.clue1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.clue1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clue1.ForeColor = System.Drawing.Color.White;
            this.clue1.Location = new System.Drawing.Point(551, 141);
            this.clue1.Name = "clue1";
            this.clue1.Size = new System.Drawing.Size(18, 20);
            this.clue1.TabIndex = 6;
            this.clue1.Text = "?";
            this.clue1.Click += new System.EventHandler(this.clue1_Click);
            // 
            // clue2
            // 
            this.clue2.AutoSize = true;
            this.clue2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.clue2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clue2.ForeColor = System.Drawing.Color.White;
            this.clue2.Location = new System.Drawing.Point(551, 208);
            this.clue2.Name = "clue2";
            this.clue2.Size = new System.Drawing.Size(18, 20);
            this.clue2.TabIndex = 7;
            this.clue2.Text = "?";
            this.clue2.Click += new System.EventHandler(this.clue2_Click);
            // 
            // Clue11
            // 
            this.Clue11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Clue11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clue11.Location = new System.Drawing.Point(575, 141);
            this.Clue11.Name = "Clue11";
            this.Clue11.Size = new System.Drawing.Size(165, 48);
            this.Clue11.TabIndex = 8;
            this.Clue11.Text = "Логин – это слово, которое будет использоваться для входа в приложение.";
            // 
            // Clue22
            // 
            this.Clue22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Clue22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clue22.Location = new System.Drawing.Point(575, 208);
            this.Clue22.Name = "Clue22";
            this.Clue22.Size = new System.Drawing.Size(165, 65);
            this.Clue22.TabIndex = 9;
            this.Clue22.Text = "Пароль – это секретный набор символов, который защищает вашу учетную запись.";
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Enter.ForeColor = System.Drawing.Color.White;
            this.Enter.Location = new System.Drawing.Point(338, 317);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(107, 34);
            this.Enter.TabIndex = 10;
            this.Enter.Text = "Вход";
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox1.Location = new System.Drawing.Point(329, 371);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 17);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Создать аккаунт";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // Error1
            // 
            this.Error1.BackColor = System.Drawing.Color.Red;
            this.Error1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Error1.ForeColor = System.Drawing.Color.White;
            this.Error1.Location = new System.Drawing.Point(12, 148);
            this.Error1.Name = "Error1";
            this.Error1.Size = new System.Drawing.Size(152, 66);
            this.Error1.TabIndex = 19;
            this.Error1.Text = "ОШИБКА: Хотя бы одна из строк была не заполнена!!!! ";
            // 
            // Error2
            // 
            this.Error2.BackColor = System.Drawing.Color.Red;
            this.Error2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Error2.ForeColor = System.Drawing.Color.White;
            this.Error2.Location = new System.Drawing.Point(12, 173);
            this.Error2.Name = "Error2";
            this.Error2.Size = new System.Drawing.Size(152, 41);
            this.Error2.TabIndex = 20;
            this.Error2.Text = "ОШИБКА: Неверный логин или пароль!!!!!!";
            // 
            // Error0
            // 
            this.Error0.BackColor = System.Drawing.Color.Red;
            this.Error0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Error0.ForeColor = System.Drawing.Color.White;
            this.Error0.Location = new System.Drawing.Point(6, 148);
            this.Error0.Name = "Error0";
            this.Error0.Size = new System.Drawing.Size(186, 70);
            this.Error0.TabIndex = 22;
            this.Error0.Text = "ОШИБКА: Произошла ошибка при чтении файла, пользовательские данные могут быть пот" +
    "еряны!!!!!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Error0);
            this.Controls.Add(this.Error2);
            this.Controls.Add(this.Error1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.Clue22);
            this.Controls.Add(this.Clue11);
            this.Controls.Add(this.clue2);
            this.Controls.Add(this.clue1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.login);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label clue1;
        private System.Windows.Forms.Label clue2;
        private System.Windows.Forms.Label Clue11;
        private System.Windows.Forms.Label Clue22;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Error1;
        private System.Windows.Forms.Label Error2;
        private System.Windows.Forms.Label Error0;
    }
}

