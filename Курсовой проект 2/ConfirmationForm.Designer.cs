
namespace Курсовой_проект_2
{
    partial class ConfirmationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonYES = new System.Windows.Forms.Button();
            this.buttonNO = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Border = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Label();
            this.Border.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonYES
            // 
            this.buttonYES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.buttonYES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonYES.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonYES.ForeColor = System.Drawing.Color.White;
            this.buttonYES.Location = new System.Drawing.Point(33, 109);
            this.buttonYES.Name = "buttonYES";
            this.buttonYES.Size = new System.Drawing.Size(118, 30);
            this.buttonYES.TabIndex = 34;
            this.buttonYES.Text = "Да";
            this.buttonYES.UseVisualStyleBackColor = false;
            this.buttonYES.Click += new System.EventHandler(this.buttonYES_Click);
            // 
            // buttonNO
            // 
            this.buttonNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.buttonNO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNO.ForeColor = System.Drawing.Color.White;
            this.buttonNO.Location = new System.Drawing.Point(179, 109);
            this.buttonNO.Name = "buttonNO";
            this.buttonNO.Size = new System.Drawing.Size(118, 30);
            this.buttonNO.TabIndex = 35;
            this.buttonNO.Text = "Нет";
            this.buttonNO.UseVisualStyleBackColor = false;
            this.buttonNO.Click += new System.EventHandler(this.buttonNO_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(48, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 63);
            this.label6.TabIndex = 36;
            this.label6.Text = "Вы уверены, что хотите удалить эту учетную запись?";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Border
            // 
            this.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Border.Controls.Add(this.label1);
            this.Border.Controls.Add(this.Exit);
            this.Border.Cursor = System.Windows.Forms.Cursors.Default;
            this.Border.Dock = System.Windows.Forms.DockStyle.Top;
            this.Border.Location = new System.Drawing.Point(0, 0);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(327, 22);
            this.Border.TabIndex = 37;
            this.Border.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Border_MouseDown);
            this.Border.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Border_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(307, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Gray;
            this.Exit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Exit.Location = new System.Drawing.Point(1200, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(22, 22);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "X";
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(327, 161);
            this.Controls.Add(this.Border);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonNO);
            this.Controls.Add(this.buttonYES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfirmationForm";
            this.Border.ResumeLayout(false);
            this.Border.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonYES;
        private System.Windows.Forms.Button buttonNO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel Border;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.Label label1;
    }
}